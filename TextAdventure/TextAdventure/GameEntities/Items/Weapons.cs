﻿using System.Collections.Generic;
using TextAdventure.Constants.Item;
using TextAdventure.Models.Item;

namespace TextAdventure.GameEntities.Item
{
    public class Weapons
    {
        // This is where all Weapon Items for the game are defined/instantiated
        // Note: These should only ever be referenced by the ItemCreator

        public static WeaponItem LetterOpener = new WeaponItem
        {
            WeaponName = "Little Letter Opener",
            InOriginalLocation = true,
            WeaponDescription = "It's really not even sharp. Maybe you could kill a rat with it?",
            OriginalPlacementDescription = "On your dresser is a small letter opener made of brass.",
            GenericPlacementDescription = "There's a little brass letter opener on the ground.",
            AttackPower = 1,
            KeywordsForPickup = ItemKeywords.LetterOpener
        };
        

        public static WeaponItem BaseballBat = new WeaponItem
        {
            WeaponName = "Baseball Bat",
            InOriginalLocation = true,
            WeaponDescription = "A solid maple wood baseball bat.",
            OriginalPlacementDescription = "You notice your old baseball bat propped up in the corner of the shed.",
            GenericPlacementDescription = "A solid wood baseball bat lays across the floor. It looks like maple wood.",
            AttackPower = 3,
            KeywordsForPickup = ItemKeywords.BaseballBat,
            WeaponTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1)
            }
        };

        public static WeaponItem Femur = new WeaponItem
        {
            WeaponName = "Femur",
            InOriginalLocation = true,
            WeaponDescription = "A human femur... There's still flesh on it...",
            OriginalPlacementDescription = "Is that... a femur... There's still flesh on it.",
            GenericPlacementDescription = "There's a... femur on the ground...",
            AttackPower = 2,
            KeywordsForPickup = ItemKeywords.Femur,
            WeaponTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(2),
                ConsoleProgram.ItemTraitCreator.DexterityIncrease(-3),
                ConsoleProgram.ItemTraitCreator.StaminaIncrease(-1),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(1),
                ConsoleProgram.ItemTraitCreator.LuckIncrease(-1),
                ConsoleProgram.ItemTraitCreator.WisdomIncrease(-5)
            }
        };

        public static WeaponItem LumberAxe = new WeaponItem
        {
            WeaponName = "Lumber Axe",
            InOriginalLocation = true,
            WeaponDescription = "An ordinary axe with a wood handle; made for chopping wood.",
            OriginalPlacementDescription = "Leaning against the burnt out campfire is a lumber axe.",
            GenericPlacementDescription = "An ordinary lumber axe is laying on the ground.",
            AttackPower = 5,
            KeywordsForPickup = ItemKeywords.LumberAxe,
            WeaponTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(1)
            }
        };

        public static WeaponItem FiremansAxe = new WeaponItem
        {
            WeaponName = "Fireman's Axe",
            InOriginalLocation = true,
            WeaponDescription = "A hefty red fireman's axe; made for breaking down doors.",
            OriginalPlacementDescription = "Leaning against the cave wall is a bright red fireman's axe.",
            GenericPlacementDescription = "A hefty red fireman's axe is laying on the ground.",
            AttackPower = 7,
            KeywordsForPickup = ItemKeywords.FiremansAxe,
            WeaponTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(2),
                ConsoleProgram.ItemTraitCreator.StaminaIncrease(1),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(2)
            }
        };

        public static WeaponItem MagnumRevolver = new WeaponItem
        {
            WeaponName = ".44 Magnum",
            InOriginalLocation = true,
            WeaponDescription = "A hefty revolver. It's been well taken care of.",
            OriginalPlacementDescription = "",
            GenericPlacementDescription = "Someone seems to have left a revolver laying on the ground here.",
            AttackPower = 20,
            AmmunitionAmount = 12,
            AmmunitionType = ItemUseTypes.Ammo44,
            KeywordsForPickup = ItemKeywords.MagnumRevolver,
            WeaponTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(4)
            }
        };

        public static WeaponItem Shotgun = new WeaponItem
        {
            WeaponName = "Shotgun",
            InOriginalLocation = true,
            WeaponDescription = "A beautiful shotgun with a wolf carved into the stock.",
            OriginalPlacementDescription = "Standing upright inside of an umbrella basket is a shotgun.",
            GenericPlacementDescription = "Someone seems to have left a shotgun laying on the ground here.",
            AttackPower = 15,
            AmmunitionAmount = 2,
            AmmunitionType = ItemUseTypes.AmmoShotgun,
            KeywordsForPickup = ItemKeywords.Shotgun,
            WeaponTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(3),
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1)
            }
        };

        public static WeaponItem GhoulRifle = new WeaponItem
        {
            WeaponName = "Ghoul Rifle",
            InOriginalLocation = true,
            WeaponDescription = "An elegant, ornate, and powerful weapon.\n" +
                                "\t\t\tFitted for a caliber of bullet you've never seen before...",
            OriginalPlacementDescription = "",
            GenericPlacementDescription = "An ornate and beautifully made rifle rests on the ground...",
            AttackPower = 75,
            AmmunitionAmount = 0,
            AmmunitionType = ItemUseTypes.AmmoGold,
            KeywordsForPickup = ItemKeywords.GhoulRifle,
            WeaponTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(2),
                ConsoleProgram.ItemTraitCreator.DexterityIncrease(5),
                ConsoleProgram.ItemTraitCreator.LuckIncrease(1),
                ConsoleProgram.ItemTraitCreator.StaminaIncrease(2),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(3)
            }
//            AttributeRequirementToSee = null,
//            AttributeRequirementToTake = null
        };

        public static WeaponItem GhoulClaws = new WeaponItem
        {
            WeaponName = "Ghoul Claws",
            InOriginalLocation = false,
            WeaponDescription = "Incredibly sharp, jagged claws from the tips of a Ghoul's bloody fingers.",
            OriginalPlacementDescription = "",
            GenericPlacementDescription = "Bloodied and sharp black objects lay strewn on the floor... \n They almost look like shards of obsidian.",
            AttackPower = 25
        };
    }
}
