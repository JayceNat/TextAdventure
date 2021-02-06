﻿using System.Collections.Generic;
using TextAdventure.Constants.Character;
using TextAdventure.Constants.Item;
using TextAdventure.Models.Item;
using TextAdventure.Models.Shared;

namespace TextAdventure.GameEntities.Item
{
    public class Items
    {
        // This is where all Inventory Items for the game are defined/instantiated
        // Note: These should only ever be referenced by the ItemCreator

        // Files to edit when adding an item: GameItems.cs, ItemCreator.cs

        public static InventoryItem Bathrobe = new InventoryItem
        {
            ItemName = "Plain Bathrobe",
            InOriginalLocation = false,
            ItemDescription = "Your plain old bathrobe. At least it's plaid-patterned.",
            OriginalPlacementDescription = "Your plaid bathrobe is on the bed.",
            GenericPlacementDescription = "Somebody's plaid bathrobe was left here.",
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.ChestWear,
            KeywordsForPickup = ItemKeywords.Bathrobe,
            InventorySpaceConsumed = 0
        };

        public static InventoryItem Flashlight = new InventoryItem
        {
            ItemName = "Flashlight",
            InOriginalLocation = true,
            ItemDescription = "A small LED flashlight that fits in your pocket.",
            OriginalPlacementDescription = "Your LED flashlight is resting on a small table, just to the left of a candle. The battery is low.\n" +
                                           "HINT: You should search your house for a battery before you leave.",
            GenericPlacementDescription = "There's a small LED flashlight resting on the ground beneath your feet.",
            KeywordsForPickup = ItemKeywords.Flashlight,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.BatteryPercentage(9)
            }
        };

        public static InventoryItem OldFlashlightBattery = new InventoryItem
        {
            ItemName = "Old Flashlight Battery",
            InOriginalLocation = true,
            ItemDescription = "A used battery for an LED flashlight. \n" +
                              "\t\t\t(Type 'use battery' to use it)",
            OriginalPlacementDescription = "On a wood shelf to your left is a flashlight battery.",
            GenericPlacementDescription = "There's a flashlight battery on the floor.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableBattery,
            KeywordsForPickup = ItemKeywords.FlashlightBattery,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.BatteryItem(12)
            },
        };

        public static InventoryItem RunningShoes = new InventoryItem
        {
            ItemName = "Running Shoes",
            InOriginalLocation = true,
            ItemDescription = "Your trusty old running shoes. You swear you run way faster in them.",
            OriginalPlacementDescription = "Your old red and white running shoes are peaking up at you from under your bed.",
            GenericPlacementDescription = "A pair of red and white running shoes are laying on the floor.",
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.FootWear,
            KeywordsForPickup = ItemKeywords.Shoes,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.LuckIncrease(1)
            },
            InventorySpaceConsumed = 0
        };

        public static InventoryItem PlainBagel = new InventoryItem
        {
            ItemName = "Plain Bagel",
            InOriginalLocation = true,
            ItemDescription = "A plain bagel. It doesn't even have cream cheese on it...",
            OriginalPlacementDescription = "There's a bagel on the counter that you'd planned to eat earlier.",
            GenericPlacementDescription = "There's a... plain bagel just lying on the floor. I don't think the 5 second rule applies here.",
            TreatItemAs = ItemUseTypes.ConsumableHealth,
            KeywordsForPickup = ItemKeywords.PlainBagel,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.HealthItem(10)
            },
            InventorySpaceConsumed = 1
        };

        public static InventoryItem TinyBackpack = new InventoryItem
        {
            ItemName = "Tiny Backpack",
            InOriginalLocation = true,
            ItemDescription = "A tiny bag made of gray nylon.",
            OriginalPlacementDescription = "Tucked behind your living room sofa is your tiny backpack, you just barely noticed it.",
            GenericPlacementDescription = "An empty gray backpack is laying on the ground... It's tiny.",
            TreatItemAs = ItemUseTypes.Bag,
            KeywordsForPickup = ItemKeywords.TinyBackpack,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarryingCapacityIncrease(2)
            },
            InventorySpaceConsumed = 0,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Luck - 1+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 1
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Luck - 1+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 1
            }
        };

        public static InventoryItem StrangeCreaturesBook = new InventoryItem
        {
            ItemName = "Book on Strange Creatures",
            InOriginalLocation = true,
            ItemDescription = "A book on mythical creatures. \n" +
                              "\t\t\tHenry (your friend who lives in a cabin across town) gave it to you.\n" +
                              "\t\t\t(Type 'use book' to read it)",
            OriginalPlacementDescription = "On a dusty metal table you spot an old book that Henry gave to you a while back.",
            GenericPlacementDescription = "A dusty old book on strange creatures is laying on the floor.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.StrangeCreaturesBookText,
            KeywordsForPickup = ItemKeywords.StrangeCreaturesBook,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Wisdom, 2),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Dexterity, 1)
            }
        };

        public static InventoryItem DirtyLetter = new InventoryItem
        {
            ItemName = "Dirty Letter",
            InOriginalLocation = true,
            ItemDescription = "It's a small, dirty letter that you found under your front doormat. \n" +
                              "\t\t\t(Type 'use letter' to read it)",
            OriginalPlacementDescription = "A small, dirty letter is sticking half way out from under your doormat.",
            GenericPlacementDescription = "A small, dirty letter is on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.DirtyLetterText,
            KeywordsForPickup = ItemKeywords.DirtyLetter
        };

        public static InventoryItem Newspaper = new InventoryItem
        {
            ItemName = "Newspaper",
            InOriginalLocation = true,
            ItemDescription = "The local newspaper that was on your driveway.",
            OriginalPlacementDescription = "There's a newspaper laying on the driveway that you forgot to pick up yesterday.",
            GenericPlacementDescription = "A copy of the local newspaper is on the ground. Looks brand new.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.NewspaperText,
            KeywordsForPickup = ItemKeywords.Newspaper,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Wisdom, 1)
            }
        };

        public static InventoryItem ScotchWhiskey = new InventoryItem
        {
            ItemName = "Scotch Whiskey",
            InOriginalLocation = true,
            ItemDescription = "It'll warm you right up.",
            OriginalPlacementDescription = "You smile as you notice a small bottle of Scotch Whiskey stashed in the corner of the shed.",
            GenericPlacementDescription = "A bottle of some good Scotch Whiskey seems to have been left here.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAttribute,
            KeywordsForPickup = ItemKeywords.ScotchWhiskey,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Stamina, 1)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Luck - 2+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 2
            }
        };

        public static InventoryItem CanvasBookBag = new InventoryItem
        {
            ItemName = "Canvas Book-Bag",
            InOriginalLocation = true,
            ItemDescription = "A decently large bag made from rugged canvas.",
            OriginalPlacementDescription = "There's a canvas book-bag sitting on the floor of the shed.",
            GenericPlacementDescription = "A rugged canvas book-bag is laying empty on the floor.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Bag,
            KeywordsForPickup = ItemKeywords.CanvasBookBag,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarryingCapacityIncrease(6)
            }
        };

        public static InventoryItem DirtyGoldBullet = new InventoryItem
        {
            ItemName = "Dirty Gold Bullet",
            InOriginalLocation = true,
            ItemDescription = "The caliber is unlike any you've ever seen. \n" +
                              "\t\t\tIt's covered in dirt, but it's clearly made of gold.",
            OriginalPlacementDescription = "In the roadside gravel, you notice something shiny glinting in the moonlight...",
            GenericPlacementDescription = "There's a dirty bullet on the ground... It looks like gold.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAmmo,
            AmmunitionType = ItemUseTypes.AmmoGold,
            KeywordsForPickup = ItemKeywords.DirtyGoldBullet,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Dexterity - 5+",
                RelevantCharacterAttribute = AttributeStrings.Dexterity,
                MinimumAttributeValue = 5
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Dexterity - 5+",
                RelevantCharacterAttribute = AttributeStrings.Dexterity,
                MinimumAttributeValue = 5
            }
        };

        public static InventoryItem WornLeatherBoots = new InventoryItem
        {
            ItemName = "Worn Leather Boots",
            InOriginalLocation = true,
            ItemDescription = "They're well used and well taken care of. The leather is dark brown.",
            OriginalPlacementDescription = "You spot a pair of leather boots tucked underneath one of the sleeping bags.",
            GenericPlacementDescription = "A pair of worn leather boots are on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.FootWear,
            KeywordsForPickup = ItemKeywords.WornLeatherBoots,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1),
            }
        };

        public static InventoryItem RabbitsFoot = new InventoryItem
        {
            ItemName = "Rabbit's Foot",
            InOriginalLocation = true,
            ItemDescription = "A small keychain holding a rabbit's foot. The cream-colored fur is incredibly soft.",
            OriginalPlacementDescription = "Tucked into a corner of the tent, near the unzipped door-flap, there's a small cream-colored object...\n" +
                                           "It looks like fur.",
            GenericPlacementDescription = "A small, cream-colored rabbit's foot rests on the ground.",
            InventorySpaceConsumed = 1,
            KeywordsForPickup = ItemKeywords.RabbitsFoot,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.LuckIncrease(4)
            }
        };

        public static InventoryItem StrangeThermos = new InventoryItem
        {
            ItemName = "Strange Thermos",
            InOriginalLocation = true,
            ItemDescription = "It seems to have some strange kind of coffee or maybe Hot Chocolate in it.\n" +
                              "\t\t\t... and it's still slightly warm.",
            OriginalPlacementDescription = "There's a thermos laying on the floor of the tent.",
            GenericPlacementDescription = "A thermos containing a strange liquid is on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableHealth,
            KeywordsForPickup = ItemKeywords.StrangeThermos,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.HealthItem(65),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Wisdom, -1)
            }
        };

        public static InventoryItem AbandonedFlashlightBattery = new InventoryItem
        {
            ItemName = "Abandoned Flashlight Battery",
            InOriginalLocation = true,
            ItemDescription = "A perfectly good battery that was left behind.",
            OriginalPlacementDescription = "A flashlight battery is sitting on one of the pillows.",
            GenericPlacementDescription = "There's a flashlight battery on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableBattery,
            KeywordsForPickup = ItemKeywords.FlashlightBattery,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.BatteryItem(21)
            }
        };

        public static InventoryItem TownCurfewNotice = new InventoryItem
        {
            ItemName = "Ashbury Resident Curfew Notice",
            InOriginalLocation = true,
            ItemDescription = "A flyer containing details on the town curfew and evening lockdowns.",
            OriginalPlacementDescription = "In a box on the bulletin board is a stack of notices with curfew information.",
            GenericPlacementDescription = "A notice about the Ashbury curfew and lockdown is on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.TownCurfewNotice,
            KeywordsForPickup = ItemKeywords.TownCurfewNotice,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Wisdom, 1)
            }
        };

        public static InventoryItem HumanTeeth = new InventoryItem
        {
            ItemName = "Human Teeth",
            InOriginalLocation = true,
            ItemDescription = "Human teeth... Why are you carrying these?",
            OriginalPlacementDescription = "In the brush under your feet, you notice small white objects.\n" +
                                           "Are those... Teeth?",
            GenericPlacementDescription = "There are human teeth on the ground...",
            InventorySpaceConsumed = 1,
            KeywordsForPickup = ItemKeywords.HumanTeeth,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DexterityIncrease(-2),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(2),
                ConsoleProgram.ItemTraitCreator.WisdomIncrease(-4)
            }
        };

        public static InventoryItem WomansNecklace = new InventoryItem
        {
            ItemName = "Woman's Necklace",
            InOriginalLocation = true,
            ItemDescription = "A silver necklace with a sapphire on it. It's beautiful.",
            OriginalPlacementDescription = "Something in the grass is glinting in the moonlight... maybe jewelry?",
            GenericPlacementDescription = "Someone left a beautiful necklace here.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.NeckWear,
            KeywordsForPickup = ItemKeywords.WomansNecklace,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.StaminaIncrease(1),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(1)
            }
        };

        public static InventoryItem BloodyJeans = new InventoryItem
        {
            ItemName = "Bloody Jeans",
            InOriginalLocation = true,
            ItemDescription = "Somebody must've been hurt pretty badly in these...",
            OriginalPlacementDescription = "Against the base of a tree, half-covered in twigs is a pair of bloody jeans...\n" +
                                           "Strangely, they're your size.",
            GenericPlacementDescription = "Somebody left bloody jeans here.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.LegWear,
            KeywordsForPickup = ItemKeywords.BloodyJeans,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1)
            }
        };

        public static InventoryItem LuckyBrandChewingGum = new InventoryItem
        {
            ItemName = "Lucky Brand! (Chewing Gum)",
            InOriginalLocation = true,
            ItemDescription = "It's strawberry flavored. The kids around town love it.",
            OriginalPlacementDescription = "Among the broken branches, leaves, and pine needles, you spot... some gum?",
            GenericPlacementDescription = "There's some chewing gum on the ground here.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAttribute,
            KeywordsForPickup = ItemKeywords.LuckyBrandChewingGum,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Luck, 1)
            }
        };

        public static InventoryItem HuntingCap = new InventoryItem
        {
            ItemName = "Hunting Cap",
            InOriginalLocation = true,
            ItemDescription = "A red flannel cap with ear flaps.",
            OriginalPlacementDescription = "On top of the rocks near the water is an upturned hat.",
            GenericPlacementDescription = "Someone's red hunting cap is on the ground here.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.HeadWear,
            KeywordsForPickup = ItemKeywords.HuntingCap,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1),
                ConsoleProgram.ItemTraitCreator.DexterityIncrease(1)
            }
        };

        public static InventoryItem MangledBallCap = new InventoryItem
        {
            ItemName = "Mangled Ball Cap",
            InOriginalLocation = true,
            ItemDescription = "A black ball cap that's seen better days.",
            OriginalPlacementDescription = "Hanging on a perch is a mangled black ball cap.",
            GenericPlacementDescription = "A mangled black ball cap is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.HeadWear,
            KeywordsForPickup = ItemKeywords.MangledBallCap,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1)
            }
        };

        public static InventoryItem PlatinumRing = new InventoryItem
        {
            ItemName = "Platinum Ring",
            InOriginalLocation = true,
            ItemDescription = "It's heavy for it's size, and fits on your index finger.",
            OriginalPlacementDescription = "Sitting on a large boulder on the riverside is a ring. You can't believe you noticed it.",
            GenericPlacementDescription = "A platinum ring has been left on the ground here.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.RingWear,
            KeywordsForPickup = ItemKeywords.PlatinumRing,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.StaminaIncrease(2)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Dexterity - 5+",
                RelevantCharacterAttribute = AttributeStrings.Dexterity,
                MinimumAttributeValue = 5
            }
        };

        public static InventoryItem SomberNote = new InventoryItem
        {
            ItemName = "Somber Note",
            InOriginalLocation = true,
            ItemDescription = "A note left by the riverside of the East Forest River.",
            OriginalPlacementDescription = "There's a folded up piece of paper wedged partially under a large boulder on the riverside.",
            GenericPlacementDescription = "There's a folded up note on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.SomberNote,
            KeywordsForPickup = ItemKeywords.SomberNote,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DexterityIncrease(1)
            }
        };

        public static InventoryItem TownSouthGateKey = new InventoryItem
        {
            ItemName = "Ashbury South Gate Key",
            InOriginalLocation = true,
            ItemDescription = "A steel key with a tag that says \"South Gate.\"",
            OriginalPlacementDescription = "Looks like there's a key taped to a large boulder near the riverside.",
            GenericPlacementDescription = "A steel key is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Key,
            KeywordsForPickup = ItemKeywords.TownSouthGateKey,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarriedItemsIncrease(0)
            }
        };

        public static InventoryItem EnergyBar = new InventoryItem
        {
            ItemName = "Energy Bar",
            InOriginalLocation = true,
            ItemDescription = "The green wrapper says \"It's pretty tasty!\"",
            OriginalPlacementDescription = "There's an energy bar in the rocks of the riverbank.",
            GenericPlacementDescription = "Some prick littered here... oh wait, it's an uneaten energy bar.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAttribute,
            KeywordsForPickup = ItemKeywords.EnergyBar,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Stamina, 1),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Strength, 1)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Luck - 5+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 5
            }
        };

        public static InventoryItem BottleOfScentMask = new InventoryItem
        {
            ItemName = "Bottle of Scent Mask",
            InOriginalLocation = true,
            ItemDescription = "It says it can prevent animals from smelling you...",
            OriginalPlacementDescription = "A bottle is laying sideways in the dirt closer to the trees.",
            GenericPlacementDescription = "A bottle of scent mask is on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAttribute,
            KeywordsForPickup = ItemKeywords.BottleOfScentMask,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Dexterity, 3),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Luck, 1)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Defense - 6+",
                RelevantCharacterAttribute = AttributeStrings.Defense,
                MinimumAttributeValue = 6
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Defense - 6+",
                RelevantCharacterAttribute = AttributeStrings.Defense,
                MinimumAttributeValue = 6
            }
        };

        public static InventoryItem BoxOf44MagnumAmmo = new InventoryItem
        {
            ItemName = "Box of .44 Magnum Ammo",
            InOriginalLocation = true,
            ItemDescription = "These bullets don't mess around.",
            OriginalPlacementDescription = "There's a box of ammo for a .44 revolver sitting behind a pile of river rocks.",
            GenericPlacementDescription = "There's a box of ammunition for a .44 revolver here.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAmmo,
            AmmunitionType = ItemUseTypes.Ammo44,
            AmmunitionAmount = 4,
            KeywordsForPickup = ItemKeywords.BoxOf44MagnumAmmo,
        };

        public static InventoryItem MuddyGoldBullet = new InventoryItem
        {
            ItemName = "Muddy Gold Bullet",
            InOriginalLocation = true,
            ItemDescription = "The caliber is unlike any you've ever seen. \n" +
                              "\t\t\tIt's covered in mud, but it's clearly made of gold.",
            OriginalPlacementDescription = "There's something gold hidden in the river rocks.",
            GenericPlacementDescription = "A gold bullet is on the ground... looks muddy.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAmmo,
            AmmunitionType = ItemUseTypes.AmmoGold,
            KeywordsForPickup = ItemKeywords.MuddyGoldBullet,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Stamina - 7+",
                RelevantCharacterAttribute = AttributeStrings.Stamina,
                MinimumAttributeValue = 7
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Stamina - 7+",
                RelevantCharacterAttribute = AttributeStrings.Stamina,
                MinimumAttributeValue = 7
            }
        };

        public static InventoryItem MiracleTonic = new InventoryItem
        {
            ItemName = "Miracle Tonic",
            InOriginalLocation = true,
            ItemDescription = "The label claims to \"Cleanse the soul, the mind, and the body.\"",
            OriginalPlacementDescription = "On the cave floor near the bedding is an old looking tonic bottle.",
            GenericPlacementDescription = "A bottle of unused Miracle Tonic is on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAttribute,
            KeywordsForPickup = ItemKeywords.MiracleTonic,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Defense, 1),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Dexterity, 1),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Luck, 1),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Stamina, 1),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Strength, 1),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Wisdom, 1)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Wisdom - 6+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 6
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Wisdom - 6+",
                RelevantCharacterAttribute = AttributeStrings.Wisdom,
                MinimumAttributeValue = 6
            }
        };

        public static InventoryItem SnakeBracelet = new InventoryItem
        {
            ItemName = "Snake Bracelet",
            InOriginalLocation = true,
            ItemDescription = "It's a really solid metal. You feel safer wearing it.",
            OriginalPlacementDescription = "Sitting on the wood table is a metal bracelet.",
            GenericPlacementDescription = "A snake bracelet is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.BraceletWear,
            KeywordsForPickup = ItemKeywords.SnakeBracelet,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(3),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(1)
            }
        };

        public static InventoryItem WaterloggedJournal = new InventoryItem
        {
            ItemName = "Waterlogged Journal",
            InOriginalLocation = true,
            ItemDescription = "A weathered leather journal from the cave behind the East Forest River waterfall.\n" +
                              "\t\t\tThere's a snake symbol stamped into the cover.",
            OriginalPlacementDescription = "On the floor under the wooden chair is a waterlogged looking journal.",
            GenericPlacementDescription = "There's a waterlogged leather journal on the floor.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.WaterloggedJournal,
            KeywordsForPickup = ItemKeywords.WaterloggedJournal,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Wisdom, 1)
            }
        };

        public static InventoryItem BloodyGoldBullet = new InventoryItem
        {
            ItemName = "Bloody Gold Bullet",
            InOriginalLocation = true,
            ItemDescription = "The caliber is unlike any you've ever seen. \n" +
                              "\t\t\tIt's covered in blood, but it's clearly made of gold.",
            OriginalPlacementDescription = "There's something gold in the pit of burnt out campfire ashes...",
            GenericPlacementDescription = "A bloody gold bullet is on the ground...",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAmmo,
            AmmunitionType = ItemUseTypes.AmmoGold,
            KeywordsForPickup = ItemKeywords.BloodyGoldBullet,
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Strength - 4+",
                RelevantCharacterAttribute = AttributeStrings.Strength,
                MinimumAttributeValue = 4
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Strength - 4+",
                RelevantCharacterAttribute = AttributeStrings.Strength,
                MinimumAttributeValue = 4
            }
        };

        public static InventoryItem BomberJacket = new InventoryItem
        {
            ItemName = "Bomber Jacket",
            InOriginalLocation = true,
            ItemDescription = "A tan, vintage looking jacket with ribbed sleeve cuffs and a wool collar.",
            OriginalPlacementDescription = "In one of the tents you can see a jacket that was left behind.",
            GenericPlacementDescription = "A vintage bomber jacket is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.ChestWear,
            KeywordsForPickup = ItemKeywords.BomberJacket,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(2),
                ConsoleProgram.ItemTraitCreator.StaminaIncrease(2)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Luck - 4+",
                RelevantCharacterAttribute = AttributeStrings.Luck,
                MinimumAttributeValue = 4
            }
        };

        public static InventoryItem BoxOfShotgunShells = new InventoryItem
        {
            ItemName = "Box of Shotgun Shells",
            InOriginalLocation = true,
            ItemDescription = "A box with some ammo for a shotgun... Could be handy.",
            OriginalPlacementDescription = "On the ground between two of the tents is an overturned box of shotgun ammo.",
            GenericPlacementDescription = "A box of shotgun shells is on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAmmo,
            AmmunitionType = ItemUseTypes.AmmoShotgun,
            KeywordsForPickup = ItemKeywords.BoxOfShotgunShells
        };

        public static InventoryItem LargeKnapsack = new InventoryItem
        {
            ItemName = "Large Knapsack",
            InOriginalLocation = true,
            ItemDescription = "It has a high carrying capacity, and it looks pretty cool.",
            OriginalPlacementDescription = "Just to the right of the camp, you spot what looks like a bag hanging in a tree.",
            GenericPlacementDescription = "A large knapsack has been left here... Seems pretty nice.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Bag,
            KeywordsForPickup = ItemKeywords.LargeKnapsack,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarryingCapacityIncrease(10)
            }
        };

        public static InventoryItem CannedMeat = new InventoryItem
        {
            ItemName = "Canned Meat",
            InOriginalLocation = true,
            ItemDescription = "Must not taste too good if it was left behind...",
            OriginalPlacementDescription = "On top of a brick pillar to the left of the gate\n" +
                                           "is an unopened can of cooked meat.",
            GenericPlacementDescription = "There's an unopened can of cooked meat on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableHealth,
            KeywordsForPickup = ItemKeywords.CannedMeat,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.HealthItem(45),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Strength, 2)
            }
        };

        public static InventoryItem TownNorthGateKey = new InventoryItem
        {
            ItemName = "Ashbury North Gate Key",
            InOriginalLocation = false,
            ItemDescription = "A steel key with a tag that says \"North Gate.\"",
            OriginalPlacementDescription = "Charlie has the North Gate Key in his pocket.",
            GenericPlacementDescription = "A steel key is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Key,
            KeywordsForPickup = ItemKeywords.TownNorthGateKey,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarriedItemsIncrease(0)
            }
        };

        public static InventoryItem TownEastGateKey = new InventoryItem
        {
            ItemName = "Ashbury East Gate Key",
            InOriginalLocation = true,
            ItemDescription = "A steel key with a tag that says \"East Gate.\"",
            OriginalPlacementDescription = "Hanging from a hook behind the front desk is a key.",
            GenericPlacementDescription = "A steel key is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Key,
            KeywordsForPickup = ItemKeywords.TownEastGateKey,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarriedItemsIncrease(0)
            }
        };

        public static InventoryItem BrandNewFlashlightBattery = new InventoryItem
        {
            ItemName = "Brand New Flashlight Battery",
            InOriginalLocation = true,
            ItemDescription = "A brand new flashlight battery.",
            OriginalPlacementDescription = "In a box near a display case of hand-knit dog collars is a battery.",
            GenericPlacementDescription = "There's a flashlight battery on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableBattery,
            KeywordsForPickup = ItemKeywords.FlashlightBattery,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.BatteryItem(98)
            }
        };

        public static InventoryItem TownDurrowHouseKey = new InventoryItem
        {
            ItemName = "Brass Key",
            InOriginalLocation = true,
            ItemDescription = "A small brass key. It looks like a house key.",
            OriginalPlacementDescription = "On the edge of the well, you notice a small brass key.",
            GenericPlacementDescription = "A small brass key is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Key,
            KeywordsForPickup = ItemKeywords.TownDurrowHouseKey,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarriedItemsIncrease(0)
            },
            AttributeRequirementToSee = new AttributeRequirement
            {
                RequirementName = "Dexterity - 7+",
                RelevantCharacterAttribute = AttributeStrings.Dexterity,
                MinimumAttributeValue = 7
            },
            AttributeRequirementToTake = new AttributeRequirement
            {
                RequirementName = "Dexterity - 8+",
                RelevantCharacterAttribute = AttributeStrings.Dexterity,
                MinimumAttributeValue = 8
            }
        };

        public static InventoryItem TownWestGateKey = new InventoryItem
        {
            ItemName = "Ashbury West Gate Key",
            InOriginalLocation = true,
            ItemDescription = "A rusted key with strange markings gouged into it...",
            OriginalPlacementDescription = "A RUSTED KEYYY!",
            GenericPlacementDescription = "A rusted key is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Key,
            KeywordsForPickup = ItemKeywords.TownWestGateKey,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarriedItemsIncrease(0)
            }
        };

        public static InventoryItem GoldWristwatch = new InventoryItem
        {
            ItemName = "Gold Wristwatch",
            InOriginalLocation = true,
            ItemDescription = "It's incredibly nice. Definitely made of gold.",
            OriginalPlacementDescription = "Laying in the dirt to the side of the road near \n" +
                                           "the gate is something shiny and gold...",
            GenericPlacementDescription = "A gold wristwatch is on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.BraceletWear,
            KeywordsForPickup = ItemKeywords.GoldWristwatch,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(4),
                ConsoleProgram.ItemTraitCreator.DexterityIncrease(2),
                ConsoleProgram.ItemTraitCreator.StrengthIncrease(2),
                ConsoleProgram.ItemTraitCreator.LuckIncrease(2)
            }
        };

        public static InventoryItem WestForestNotice = new InventoryItem
        {
            ItemName = "West Forest Notice",
            InOriginalLocation = true,
            ItemDescription = "A crinkled and weathered parchment with info on the West Forest.",
            OriginalPlacementDescription = "On the ground under a bench is a weathered piece of paper.",
            GenericPlacementDescription = "There's a notice about the West Forest on the floor.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.WestForestNotice,
            KeywordsForPickup = ItemKeywords.WestForestNotice,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Wisdom, 1)
            }
        };

        public static InventoryItem Crowbar = new InventoryItem
        {
            ItemName = "Crowbar",
            InOriginalLocation = true,
            ItemDescription = "A heavy and effective tool for breaking and entering.",
            OriginalPlacementDescription = "Laying over old Emmett Skepp's foot is a crowbar.",
            GenericPlacementDescription = "There's a crowbar on the ground.",
            InventorySpaceConsumed = 2,
            KeywordsForPickup = ItemKeywords.Crowbar,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarriedItemsIncrease(2)
            }
        };

        public static InventoryItem ToyBoat = new InventoryItem
        {
            ItemName = "Toy Boat",
            InOriginalLocation = true,
            ItemDescription = "A small toy boat made of plastic. \n" +
                              "\t\t\t\"Charlie\" is scribbled on the bottom.",
            OriginalPlacementDescription = "Resting solemnly on the fountain is a forgotten toy boat.",
            GenericPlacementDescription = "A toy boat is on the ground.",
            InventorySpaceConsumed = 1,
            KeywordsForPickup = ItemKeywords.ToyBoat
        };

        public static InventoryItem BottleOfRum = new InventoryItem
        {
            ItemName = "Bottle of Rum",
            InOriginalLocation = true,
            ItemDescription = "It's nearly empty, but there's enough to perk you up.",
            OriginalPlacementDescription = "Sitting upright next to the leg of a bench is a bottle of rum.",
            GenericPlacementDescription = "There's a bottle of rum on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.ConsumableAttribute,
            KeywordsForPickup = ItemKeywords.BottleOfRum,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Strength, 2),
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.MaxCarryingCapacity, 2),
            }
        };

        public static InventoryItem SteelToedBoots = new InventoryItem
        {
            ItemName = "Steel Toed Boots",
            InOriginalLocation = true,
            ItemDescription = "They're very sturdy, and surprisingly very comfortable.",
            OriginalPlacementDescription = "FIX STEEL TOE BOOTS",
            GenericPlacementDescription = "A pair of steel toed boots are on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.FootWear,
            KeywordsForPickup = ItemKeywords.SteelToedBoots,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(3)
            }
        };

        public static InventoryItem ForestGreenCargoPants = new InventoryItem
        {
            ItemName = "Forest Green Cargo Pants",
            InOriginalLocation = true,
            ItemDescription = "Not too stylish, but they are really useful.",
            OriginalPlacementDescription = "Folded neatly on an ottoman near the front door is \n" +
                                           "a pair of forest green cargo pants.",
            GenericPlacementDescription = "A pair of green cargo pants are on the ground.",
            InventorySpaceConsumed = 0,
            TreatItemAs = ItemUseTypes.Wearable,
            WearableType = ItemUseTypes.LegWear,
            KeywordsForPickup = ItemKeywords.CargoPants,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.CarryingCapacityIncrease(2),
                ConsoleProgram.ItemTraitCreator.DefenseIncrease(1)
            }
        };

        public static InventoryItem ChildsDrawing = new InventoryItem
        {
            ItemName = "Child's Drawing",
            InOriginalLocation = true,
            ItemDescription = "Various crayon colors on lined paper.",
            OriginalPlacementDescription = "Propped up against the left wall on an entryway table is\n" +
                                           "a child's drawing.",
            GenericPlacementDescription = "There's a piece of paper with a child's artwork on the floor.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.ChildsDrawing,
            KeywordsForPickup = ItemKeywords.ChildsDrawing,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Strength, 1)
            }
        };

        public static InventoryItem NoteToRobertDurrow = new InventoryItem
        {
            ItemName = "Note to Robert Durrow",
            InOriginalLocation = true,
            ItemDescription = "It's handwritten in cursive.",
            OriginalPlacementDescription = "You notice a folded piece of paper tucked underneath\n" +
                                           "a decorative bowl on a table near the door.",
            GenericPlacementDescription = "A small folded note is on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.NoteToRobertDurrow,
            KeywordsForPickup = ItemKeywords.NoteToRobertDurrow,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Strength, 1)
            }
        };

        public static InventoryItem MissingPersonPosterLucy = new InventoryItem
        {
            ItemName = "Missing Person Poster for Lucy Durrow",
            InOriginalLocation = true,
            ItemDescription = DocumentTexts.MissingPersonPosterDescription,
            OriginalPlacementDescription = "Trapped low to the ground in a tall patch of grass to the\n" +
                                           "left of the gate is a missing person poster.",
            GenericPlacementDescription = "There's a missing person poster on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.MissingPersonLucy,
            KeywordsForPickup = ItemKeywords.MissingPersonPoster,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Dexterity, 1)
            }
        };

        public static InventoryItem MissingPersonPosterPenny = new InventoryItem
        {
            ItemName = "Missing Person Poster for Penny Lune",
            InOriginalLocation = true,
            ItemDescription = DocumentTexts.MissingPersonPosterDescription,
            OriginalPlacementDescription = "There's a missing person poster that's been stapled to a tree.",
            GenericPlacementDescription = "There's a missing person poster on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.MissingPersonPenny,
            KeywordsForPickup = ItemKeywords.MissingPersonPoster,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Defense, 1)
            }
        };

        public static InventoryItem MissingPersonPosterSimon = new InventoryItem
        {
            ItemName = "Missing Person Poster for Simon Durrow",
            InOriginalLocation = true,
            ItemDescription = DocumentTexts.MissingPersonPosterDescription,
            OriginalPlacementDescription = "Pasted at a crooked angle on the ice cream shop window \n" +
                                           "is a missing person poster.",
            GenericPlacementDescription = "There's a missing person poster on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.MissingPersonSimon,
            KeywordsForPickup = ItemKeywords.MissingPersonPoster,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Luck, 1)
            }
        };

        public static InventoryItem MissingPersonPosterArthur = new InventoryItem
        {
            ItemName = "Missing Person Poster for Arthur Walden",
            InOriginalLocation = true,
            ItemDescription = DocumentTexts.MissingPersonPosterDescription,
            OriginalPlacementDescription = "You notice a missing person poster sticking halfway out of a trashcan.",
            GenericPlacementDescription = "There's a missing person poster on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.MissingPersonArthur,
            KeywordsForPickup = ItemKeywords.MissingPersonPoster,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Strength, 1)
            }
        };

        public static InventoryItem MissingPersonPosterDuncan = new InventoryItem
        {
            ItemName = "Missing Person Poster for Duncan Travis",
            InOriginalLocation = true,
            ItemDescription = DocumentTexts.MissingPersonPosterDescription,
            OriginalPlacementDescription = "On the ground of the open lot is a poster swirling lightly in the wind.",
            GenericPlacementDescription = "There's a missing person poster on the ground.",
            InventorySpaceConsumed = 1,
            TreatItemAs = ItemUseTypes.Document,
            DocumentText = DocumentTexts.MissingPersonDuncan,
            KeywordsForPickup = ItemKeywords.MissingPersonPoster,
            ItemTraits = new List<ItemTrait>
            {
                ConsoleProgram.ItemTraitCreator.ConsumedAttributeItem(AttributeStrings.Dexterity, 1)
            }
        };
    }
}
