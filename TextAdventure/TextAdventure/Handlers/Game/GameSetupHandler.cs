using Console = Colorful.Console;
using System;
using System.Drawing;
using System.IO;
using System.Xml;
using TextAdventure.Constants.Shared;
using TextAdventure.Handlers.Room;
using TextAdventure.Models.Game;
using TextAdventure.Utilities;
using Colorful;

namespace TextAdventure.Handlers.Game
{
    public class GameSetupHandler
    {
        public static void DisplayGameTitle(GameTitle gameTitle)
        {
            var font = FigletFont.Default;
            var figlet = new Figlet(font);

            Console.ReplaceAllColorsWithDefaults();
            Console.WriteLine(figlet.ToAscii(gameTitle.Title), gameTitle.TitleTextColor);
            Console.WriteLine();
            Console.WriteLine("\t\t-- Written by " + gameTitle.Author + "--", gameTitle.AuthorTextColor);
            Console.WriteLine("\n\n");
            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
            Console.ReplaceAllColorsWithDefaults();
            Console.Clear();
        }

        // This displays after the user assigns their traits and begins the game
        public static void DisplayGameIntro()
        {
            Console.ReplaceAllColorsWithDefaults();

            var enterKeyPressed = false;
            var r = 255;
            var g = 255;
            var b = 255;
            foreach (var line in ConsoleStrings.GameIntro)
            {
                if (enterKeyPressed)
                {
                    Console.WriteLine(line, Color.FromArgb(r, g, b));
                }
                else
                {
                    enterKeyPressed = TypingAnimation.Animate(line, Color.FromArgb(r, g, b));
                }

                g -= 25;
                b -= 25;
            }

            Console.WriteWithGradient(ConsoleStrings.PressEnterPrompt, Color.Yellow, Color.DarkRed, 4);
            Console.ReadLine();
        }

        // Kind of a goofy method... but allows us to skip displaying the intro if we need to
        public static void BeginAdventure(Models.Character.Character player, Models.Room.Room room)
        {
            DisplayGameIntro();
            TheAdventure(player, room, true);
        }

        // This is the main game loop, and only stops when the player goes into a 'null' room (or saves)
        public static void TheAdventure(Models.Character.Character player, Models.Room.Room room, bool firstRoomEntered)
        {
            var firstRoom = firstRoomEntered;
            var currentRoom = room;
            while (true)
            {
                currentRoom = RoomHandler.EnterRoom(player, currentRoom, firstRoom);
                firstRoom = false;
                if (currentRoom == null)
                {
                    break;
                }

                if (currentRoom.RoomName == ConsoleStrings.SaveGame)
                {
                    SaveGame();
                    break;
                }
            }
        }

        // Serialize all objects to save the game state
        public static void SaveGame()
        {
            // This is needed to prevent a circular dependency (our roomExits are Room Models which have roomExits which are Room Models...)
            ConsoleProgram.RoomCreator.RemoveExitsFromAllRooms();

            // This will create a file in the same directory as the .exe since we didn't specify a path
            using (var xmlWriter = XmlWriter.Create("TheHaunting_SavedGame.xml", new XmlWriterSettings { Indent = true }))
            {
                xmlWriter.WriteStartElement("root");

                // We only need to serialize the biggest objects; all the other ones are children of them

                // Characters
                ConsoleProgram.CharacterSerializer.Serialize(xmlWriter, ConsoleProgram.CharacterCreator.Player);
                ConsoleProgram.CharacterSerializer.Serialize(xmlWriter, ConsoleProgram.CharacterCreator.Ghoul);
                
                // Rooms
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourBedroom);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourLivingRoom);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourKitchen);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourBasement);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourFrontEntryway);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourFrontPorch);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourShed);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.YourDriveway);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.RoadConnectingYourHouseToTown);

                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.ForestLake);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.ForestLakeTent);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.EastForest);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.EastForestLowerClearing);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.EastForestUpperClearing);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.DeepEastForest);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.DeepEastForestLowerRiver);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.DeepEastForestUpperRiver);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.DeepEastForestUpperRiverCave);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.EastForestCampground);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.PathBetweenCampAndEastRoad);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.EastRoadToTown);

                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.TownSouthEntrance);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.TownNorthEntrance);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.TownEastEntrance);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.TownWestEntrance);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthSquare);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburyNorthSquare);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburyEastSquare);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburyWestSquare);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthMainStreet);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburyNorthMainStreet);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburyEastPlaza);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburyWestPlaza);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburyTownCenter);
                // South Side
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthSquareEastAlley);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthEastVeterinaryClinic);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthEastCornerLot);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthEastDurrowHouse);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthEastAviary);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthEastWell);
                ConsoleProgram.RoomSerializer.Serialize(xmlWriter, ConsoleProgram.RoomCreator.AshburySouthSquareWestAlley);
            }
        }

        public static bool TryLoadGame()
        {
            const string saveFile = "TheHaunting_SavedGame.xml";
            if (File.Exists(saveFile) && File.ReadAllText(saveFile).Length != 0)
            {
                TypingAnimation.Animate("A save file was found, would you like to load it? (y/n)", Color.DarkOrange);
                Console.Write(">", Color.DarkOrange);
                var response = System.Console.ReadLine();
                if (string.IsNullOrEmpty(response) || response?.ToLower()[0] == 'y')
                {
                    try
                    {
                        using (var reader = XmlReader.Create(saveFile))
                        {
                            // Skip root node
                            reader.ReadToFollowing("C"); // Name of first class, we serialize Character as "C" for XML sneakiness :)

                            // Characters
                            ConsoleProgram.CharacterCreator.Player = (Models.Character.Character)ConsoleProgram.CharacterSerializer.Deserialize(reader);
                            ConsoleProgram.CharacterCreator.Ghoul = (Models.Character.Character)ConsoleProgram.CharacterSerializer.Deserialize(reader);

                            // Rooms
                            ConsoleProgram.RoomCreator.YourBedroom = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.YourLivingRoom = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.YourKitchen = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.YourBasement = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.YourFrontEntryway = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.YourFrontPorch = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.YourShed = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.YourDriveway = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.RoadConnectingYourHouseToTown = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);

                            ConsoleProgram.RoomCreator.ForestLake = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.ForestLakeTent = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.EastForest = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.EastForestLowerClearing = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.EastForestUpperClearing = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.DeepEastForest = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.DeepEastForestLowerRiver = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.DeepEastForestUpperRiver = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.DeepEastForestUpperRiverCave = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.EastForestCampground = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.PathBetweenCampAndEastRoad = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.EastRoadToTown = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);

                            ConsoleProgram.RoomCreator.TownSouthEntrance = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.TownNorthEntrance = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.TownEastEntrance = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.TownWestEntrance = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthSquare = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburyNorthSquare = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburyEastSquare = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburyWestSquare = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthMainStreet = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburyNorthMainStreet = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburyEastPlaza = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburyWestPlaza = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburyTownCenter = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            // South Side
                            ConsoleProgram.RoomCreator.AshburySouthSquareEastAlley = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthEastVeterinaryClinic = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthEastCornerLot = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthEastDurrowHouse = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthEastAviary = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthEastWell = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                            ConsoleProgram.RoomCreator.AshburySouthSquareWestAlley = (Models.Room.Room)ConsoleProgram.RoomSerializer.Deserialize(reader);
                        }

                        Console.Clear();
                        // Important that we add all the room exits back to the rooms, or we can't go anywhere!
                        ConsoleProgram.RoomCreator.AddExitsToAllRooms();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.Write("\nSomething went wrong loading the file :( ...", Color.Red);
                        Console.ReadLine();
                        Console.Clear();
                        Environment.Exit(0);
                    }
                }
            }

            Console.Clear();
            return false;
        }

        // This method is needed in order to place the player in the proper room object after the exits have been re-added,
        // otherwise we would place the player in a room object with no exits 
        public static Models.Room.Room GetCurrentRoomFromRoomName(string playerCurrentLocation)
        {
            // Your House
            #region Your House

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourBedroom.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourBedroom;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourLivingRoom.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourLivingRoom;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourKitchen.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourKitchen;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourBasement.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourBasement;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourFrontEntryway.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourFrontEntryway;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourFrontPorch.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourFrontPorch;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourShed.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourShed;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.YourDriveway.RoomName)
            {
                return ConsoleProgram.RoomCreator.YourDriveway;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.RoadConnectingYourHouseToTown.RoomName)
            {
                return ConsoleProgram.RoomCreator.RoadConnectingYourHouseToTown;
            }

            #endregion

            // Forest
            #region Forest

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.ForestLake.RoomName)
            {
                return ConsoleProgram.RoomCreator.ForestLake;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.ForestLakeTent.RoomName)
            {
                return ConsoleProgram.RoomCreator.ForestLakeTent;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.EastForest.RoomName)
            {
                return ConsoleProgram.RoomCreator.EastForest;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.EastForestLowerClearing.RoomName)
            {
                return ConsoleProgram.RoomCreator.EastForestLowerClearing;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.EastForestUpperClearing.RoomName)
            {
                return ConsoleProgram.RoomCreator.EastForestUpperClearing;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.DeepEastForest.RoomName)
            {
                return ConsoleProgram.RoomCreator.DeepEastForest;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.DeepEastForestLowerRiver.RoomName)
            {
                return ConsoleProgram.RoomCreator.DeepEastForestLowerRiver;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.DeepEastForestUpperRiver.RoomName)
            {
                return ConsoleProgram.RoomCreator.DeepEastForestUpperRiver;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.DeepEastForestUpperRiverCave.RoomName)
            {
                return ConsoleProgram.RoomCreator.DeepEastForestUpperRiverCave;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.EastForestCampground.RoomName)
            {
                return ConsoleProgram.RoomCreator.EastForestCampground;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.PathBetweenCampAndEastRoad.RoomName)
            {
                return ConsoleProgram.RoomCreator.PathBetweenCampAndEastRoad;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.EastRoadToTown.RoomName)
            {
                return ConsoleProgram.RoomCreator.EastRoadToTown;
            }

            #endregion

            // Town
            #region Town

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.TownSouthEntrance.RoomName)
            {
                return ConsoleProgram.RoomCreator.TownSouthEntrance;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.TownNorthEntrance.RoomName)
            {
                return ConsoleProgram.RoomCreator.TownNorthEntrance;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.TownEastEntrance.RoomName)
            {
                return ConsoleProgram.RoomCreator.TownEastEntrance;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.TownWestEntrance.RoomName)
            {
                return ConsoleProgram.RoomCreator.TownWestEntrance;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthSquare.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthSquare;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburyNorthSquare.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburyNorthSquare;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburyEastSquare.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburyEastSquare;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburyWestSquare.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburyWestSquare;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthMainStreet.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthMainStreet;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburyNorthMainStreet.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburyNorthMainStreet;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburyEastPlaza.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburyEastPlaza;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburyWestPlaza.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburyWestPlaza;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburyTownCenter.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburyTownCenter;
            }

            //************** SOUTH SIDE **************

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthSquareEastAlley.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthSquareEastAlley;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthEastVeterinaryClinic.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthEastVeterinaryClinic;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthEastCornerLot.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthEastCornerLot;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthEastDurrowHouse.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthEastDurrowHouse;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthEastAviary.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthEastAviary;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthEastWell.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthEastWell;
            }

            if (playerCurrentLocation == ConsoleProgram.RoomCreator.AshburySouthSquareWestAlley.RoomName)
            {
                return ConsoleProgram.RoomCreator.AshburySouthSquareWestAlley;
            }

            #endregion

            return ConsoleProgram.RoomCreator.YourBedroom;
        }
    }
}
