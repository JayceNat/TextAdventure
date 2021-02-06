using System.Collections.Generic;
using TextAdventure.Constants.Character;
using TextAdventure.Models.Item;

namespace TextAdventure.GameEntities.Character
{
    public class Characters
    {
        // This is where all Characters for the game are defined/instantiated
        // Note: These should only ever be referenced by the CharacterCreator

        public static Models.Character.Character Player = new Models.Character.Character
        {
            Name = null,
            CharacterType = CharacterTypes.Player,
            Attributes = ConsoleProgram.AttributeCreator.PlayerAttributes,
            CarriedItems = new List<InventoryItem>
            {
                ConsoleProgram.ItemCreator.Bathrobe
            }
        };

        public static Models.Character.Character Charlie = new Models.Character.Character
        {
            Name = "Charlie",
            OnMeetDescription = "There's a small boy here, hiding from you in the shadows.",
            CharacterPhrases = new List<string>
            {
                "You ask him his name, he cautiously says \"Charlie.\"",
                "The boy tells you about his toy boat that he lost somewhere on the West side of town.",
                "The boy looks sad... he tells you he lost his favorite toy boat somewhere in town.",
                "You notice he's fiddling with what looks like a town gate key.",
                "It looks like he's holding a town gate key in his hands."
            },
            CharacterAppeasedPhrases = new List<string>
            {
                "Charlie seems happy to have his toy boat back."
            },
            CharacterKeywords = new List<string>
            {
                "charlie", "boy", "kid"
            },
            DesiredItem = ConsoleProgram.ItemCreator.ToyBoat,
            OfferedItem = ConsoleProgram.ItemCreator.TownNorthGateKey,
            CharacterType = CharacterTypes.Friendly,
            CurrentRoomName = null,
            MaximumHealthPoints = 30 + 
                                  (CharacterDefaults.HealthPerStaminaPointIncrease * ConsoleProgram.AttributeCreator.CharlieAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = 30 + 
                           (CharacterDefaults.HealthPerStaminaPointIncrease * ConsoleProgram.AttributeCreator.CharlieAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = ConsoleProgram.AttributeCreator.CharlieAttributes
        };

        public static Models.Character.Character Henry = new Models.Character.Character
        {
            Name = "Henry",
            CharacterType = CharacterTypes.Friendly,
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                                  + (CharacterDefaults.HealthPerStaminaPointIncrease * ConsoleProgram.AttributeCreator.HenryAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterDefaults.HealthPerStaminaPointIncrease * ConsoleProgram.AttributeCreator.HenryAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = ConsoleProgram.AttributeCreator.HenryAttributes,
            WeaponItem = ConsoleProgram.ItemCreator.MagnumRevolver
        };

        public static Models.Character.Character Ghoul = new Models.Character.Character
        {
            Name = "The Ghoul",
            CharacterType = CharacterTypes.Enemy,
            MaximumHealthPoints = CharacterDefaults.DefaultMaximumHealthPoints 
                                  + (CharacterDefaults.HealthPerStaminaPointIncrease * ConsoleProgram.AttributeCreator.GhoulAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            HealthPoints = CharacterDefaults.DefaultMaximumHealthPoints
                           + (CharacterDefaults.HealthPerStaminaPointIncrease * ConsoleProgram.AttributeCreator.GhoulAttributes.Stamina - CharacterDefaults.DefaultValueForAllAttributes),
            Attributes = ConsoleProgram.AttributeCreator.GhoulAttributes,
            WeaponItem = ConsoleProgram.ItemCreator.GhoulClaws
        };
    }
}
