﻿using System.Drawing;
using System.Xml.Serialization;
using TextAdventure.Handlers.Character;
using TextAdventure.Handlers.Game;
using TextAdventure.Implementations.Character;
using TextAdventure.Implementations.Item;
using TextAdventure.Implementations.Room;
using TextAdventure.Interfaces.Character;
using TextAdventure.Interfaces.Item;
using TextAdventure.Interfaces.Room;
using TextAdventure.Models.Game;

namespace TextAdventure
{
    public class ConsoleProgram
    {
        // Used for saving the game
        public static XmlSerializer GameTitleSerializer = new XmlSerializer(typeof(GameTitle));
        public static XmlSerializer CharacterSerializer = new XmlSerializer(typeof(Models.Character.Character));
        public static XmlSerializer RoomSerializer = new XmlSerializer(typeof(Models.Room.Room));

        // These will build/create our Trait, Attr, Item, Character and Room objects from Game*.cs files
        // The order here is important, as some objects depend on others to already exist
        public static readonly IItemTraitCreator ItemTraitCreator = new ItemTraitCreator();
        public static readonly IAttributeCreator AttributeCreator = new AttributeCreator();
        public static readonly IItemCreator ItemCreator = new ItemCreator();
        public static readonly ICharacterCreator CharacterCreator = new CharacterCreator();
        public static readonly IRoomCreator RoomCreator = new RoomCreator();

        public static GameTitle GameTitle = new GameTitle
        {
            Title = "Ashbury Haunting",
            TitleTextColor = Color.Brown,

            Author = "Jayce Meyer",
            AuthorTextColor = Color.DimGray
        };

        public ConsoleProgram(XmlSerializer gameTitleSerializer, XmlSerializer characterSerializer, XmlSerializer roomSerializer)
        {
            GameTitleSerializer = gameTitleSerializer;
            CharacterSerializer = characterSerializer;
            RoomSerializer = roomSerializer;
        }

        // This is the Entry Point for the entire Game (the console application)
        private static void Main()
        {
            // Helper to pretty up and print the above variable
            GameSetupHandler.DisplayGameTitle(GameTitle);

            // If a save file exists, ask to load it
            var gameLoaded = GameSetupHandler.TryLoadGame();

            // This calls the Interface to { get; } a reference to our Player object we built earlier
            var player = CharacterCreator.Player;

            if (!gameLoaded)
            {
                // Gets the players name from console input
                PlayerSetupHandler.WelcomePlayer(player);

                // User assigns their starting traits
                PlayerSetupHandler.SetPlayerTraits(player);

                // Game ends once 'BeginAdventure' returns
                GameSetupHandler.BeginAdventure(player, RoomCreator.YourBedroom);
            }
            else
            {
                // Shortcut the call to TheAdventure so we don't print the gameIntro when we load from save
                var roomToLoad = GameSetupHandler.GetCurrentRoomFromRoomName(CharacterCreator.Player.CurrentRoomName);
                GameSetupHandler.TheAdventure(player, roomToLoad, false);
            }
        }
    }
}
