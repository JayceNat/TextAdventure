﻿using Colorful;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TextAdventure.Constants.Character;
using TextAdventure.Constants.Item;
using TextAdventure.Constants.Shared;
using TextAdventure.Handlers.Character;
using TextAdventure.Handlers.Room;
using TextAdventure.Models.Item;
using TextAdventure.Utilities;

namespace TextAdventure.Handlers.Item
{
    public class InventoryHandler
    {
        // This updates the room and/or player when the exchange of an item occurs
        public static void HandleItemAddOrRemove(Models.Character.Character player, Models.Room.Room currentRoom,
            Items foundItem, bool removeItemFromRoom = false)
        {
            switch (removeItemFromRoom)
            {
                // We are removing an item from a room, adding it to player inventory
                case true:
                    if (foundItem?.InventoryItems?.First() != null)
                    {
                        var meetsAnyRequirement = false;
                        var needsToDropSameTypeItemFirst = false;
                        InventoryItem carriedItemOfSameType = null;
                        var inventoryItemToAddToPlayer = foundItem.InventoryItems.First();

                        if (inventoryItemToAddToPlayer?.AttributeRequirementToTake == null) meetsAnyRequirement = true;

                        else if (inventoryItemToAddToPlayer?.AttributeRequirementToTake != null
                            && CanPickupItemWithAttributeRequirement(player, inventoryItemToAddToPlayer))
                        {
                            meetsAnyRequirement = true;
                        }

                        if (inventoryItemToAddToPlayer.TreatItemAs == ItemUseTypes.Bag
                            || inventoryItemToAddToPlayer.TreatItemAs == ItemUseTypes.Wearable)
                        {
                            foreach (var item in player.CarriedItems)
                            {
                                if (item.TreatItemAs == ItemUseTypes.Bag && inventoryItemToAddToPlayer.TreatItemAs == ItemUseTypes.Bag
                                    || item.WearableType != "" && item.WearableType == inventoryItemToAddToPlayer.WearableType)
                                {
                                    carriedItemOfSameType = item;
                                    needsToDropSameTypeItemFirst = true;
                                    break;
                                }
                            }
                        }

                        if (PickupOrDropItemIsOk(player, foundItem) && meetsAnyRequirement)
                        {
                            Console.WriteLine();
                            if (needsToDropSameTypeItemFirst)
                            {
                                TypingAnimation.Animate("You need to drop your " + carriedItemOfSameType.ItemName + " before you can take the " + inventoryItemToAddToPlayer?.ItemName + ".\n",
                                Color.ForestGreen);
                            }
                            else
                            {
                                AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, inventoryItemToAddToPlayer);
                                inventoryItemToAddToPlayer.InOriginalLocation = false;
                                player.CarriedItems.Add(inventoryItemToAddToPlayer);
                                player.Attributes.CarriedItemsCount += inventoryItemToAddToPlayer.InventorySpaceConsumed;
                                currentRoom.RoomItems.InventoryItems.Remove(inventoryItemToAddToPlayer);
                                TypingAnimation.Animate("You take the " + inventoryItemToAddToPlayer.ItemName + ".\n", Color.ForestGreen);
                            }
                        }

                        else
                        {
                            if (meetsAnyRequirement)
                            {
                                Console.WriteLine();
                                TypingAnimation.Animate("Your inventory is full! \n" +
                                                        "Drop or use an item to pick up the " + inventoryItemToAddToPlayer?.ItemName + ".\n", Color.DarkOliveGreen);
                            }
                        }
                    }
                    else
                    if (foundItem?.WeaponItems != null)
                    {
                        var weaponItemToAddToPlayer = foundItem.WeaponItems.First();
                        if (string.IsNullOrEmpty(player.WeaponItem.WeaponName))
                        {
                            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponItemToAddToPlayer);
                            weaponItemToAddToPlayer.InOriginalLocation = false;
                            player.WeaponItem = weaponItemToAddToPlayer;
                            currentRoom.RoomItems.WeaponItems.Remove(weaponItemToAddToPlayer);
                            Console.WriteLine();
                            TypingAnimation.Animate("You take the " + weaponItemToAddToPlayer?.WeaponName + ".\n", Color.ForestGreen);
                        }
                        else
                        {
                            var oldWeapon = player.WeaponItem.WeaponName.Clone();
                            DropWeaponAndPickupNew(player, currentRoom, weaponItemToAddToPlayer);
                            player.WeaponItem = weaponItemToAddToPlayer;
                            currentRoom.RoomItems.WeaponItems.Remove(weaponItemToAddToPlayer);
                            Console.WriteLine();
                            TypingAnimation.Animate("You drop your " + oldWeapon + " for the " + weaponItemToAddToPlayer?.WeaponName + ".\n",
                                Color.ForestGreen);
                        }
                    }

                    break;

                // We are adding an item to a room, removing/dropping it from player inventory
                case false:
                    if (foundItem?.InventoryItems != null)
                    {
                        var inventoryItemToRemoveFromPlayer = foundItem.InventoryItems.First();

                        DropItemInRoom(player, currentRoom, inventoryItemToRemoveFromPlayer);
                        Console.WriteLine();
                        TypingAnimation.Animate("You drop the " + inventoryItemToRemoveFromPlayer?.ItemName + ".\n", Color.ForestGreen);
                    }
                    else if (foundItem?.WeaponItems != null)
                    {
                        var weaponItemToRemoveFromPlayer = foundItem.WeaponItems.First();

                        DropWeaponInRoom(player, currentRoom);
                        Console.WriteLine();
                        TypingAnimation.Animate("You drop the " + weaponItemToRemoveFromPlayer?.WeaponName + ".\n", Color.ForestGreen);
                    }

                    break;
            }
        }

        public static bool CanPickupItemWithAttributeRequirement(Models.Character.Character player, InventoryItem inventoryItem = null, WeaponItem weaponItem = null)
        {
            if (weaponItem != null)
            {
                Console.WriteLine();
                if (PlayerMeetsRequirementForItem(player, weaponItem: weaponItem))
                {
                    TypingAnimation.Animate($"<{weaponItem.AttributeRequirementToTake.RequirementName}>!", Color.Gold);
                    weaponItem.AttributeRequirementToSee = null;
                    weaponItem.AttributeRequirementToTake = null;
                    return true;
                }

                TypingAnimation.Animate($"You need: <{weaponItem.AttributeRequirementToTake.RequirementName}> to take the {weaponItem.WeaponName}. \n",
                    Color.DarkGoldenrod);
                return false;
            }

            if (inventoryItem != null)
            {
                Console.WriteLine();
                if (PlayerMeetsRequirementForItem(player, inventoryItem: inventoryItem))
                {
                    TypingAnimation.Animate($"<{inventoryItem.AttributeRequirementToTake.RequirementName}>!",
                        Color.Gold);
                    inventoryItem.AttributeRequirementToSee = null;
                    inventoryItem.AttributeRequirementToTake = null;
                    return true;
                }

                TypingAnimation.Animate($"You need: <{inventoryItem.AttributeRequirementToTake.RequirementName}> to take the {inventoryItem.ItemName}. \n",
                    Color.DarkGoldenrod);
                return false;
            }

            return false;
        }

        public static bool PickupOrDropItemIsOk(Models.Character.Character player, Items foundItem, bool pickingUpItem = true)
        {
            if (foundItem?.WeaponItems != null)
            {
                return true;
            }

            if (foundItem?.InventoryItems == null) return false;
            if (pickingUpItem &&
                player.Attributes.CarriedItemsCount + foundItem.InventoryItems.First().InventorySpaceConsumed >
                player.Attributes.MaximumCarryingCapacity)
                return false;
            if (foundItem.InventoryItems?.First()?.ItemTraits == null &&
                player.Attributes.CarriedItemsCount + foundItem.InventoryItems.First().InventorySpaceConsumed <=
                player.Attributes.MaximumCarryingCapacity)
                return true;

            foreach (var itemTrait in foundItem.InventoryItems.First().ItemTraits)
            {
                if (pickingUpItem)
                {
                    if (itemTrait.RelevantCharacterAttribute != AttributeStrings.MaxCarryingCapacity
                        && player.Attributes.CarriedItemsCount + foundItem.InventoryItems.First().InventorySpaceConsumed > player.Attributes.MaximumCarryingCapacity)
                    {
                        return false;
                    }

                    if (itemTrait.RelevantCharacterAttribute == AttributeStrings.MaxCarryingCapacity
                        && player.Attributes.MaximumCarryingCapacity + itemTrait.TraitValue < player.Attributes.CarriedItemsCount)
                    {
                        return false;
                    }

                    return itemTrait.RelevantCharacterAttribute != AttributeStrings.CarriedItemsCount
                           || player.Attributes.CarriedItemsCount + itemTrait.TraitValue <= player.Attributes.MaximumCarryingCapacity;
                }

                if (itemTrait.RelevantCharacterAttribute != AttributeStrings.MaxCarryingCapacity)
                {
                    return true;
                }

                if (player.Attributes.MaximumCarryingCapacity - itemTrait.TraitValue <
                    player.Attributes.CarriedItemsCount)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool PlayerMeetsRequirementForItem(Models.Character.Character player, bool takeItem = true, InventoryItem inventoryItem = null, WeaponItem weaponItem = null)
        {
            if (inventoryItem != null)
            {
                if (takeItem)
                {
                    return PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, inventoryItem.AttributeRequirementToTake);
                }

                return PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, inventoryItem.AttributeRequirementToSee);
            }

            if (weaponItem != null)
            {
                if (takeItem)
                {
                    return PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, weaponItem.AttributeRequirementToTake);
                }

                return PlayerAttributeComparer.ComparePlayerTraitsToAttributeRequirement(player, weaponItem.AttributeRequirementToSee);
            }

            return false;
        }

        public static void DropItemInRoom(Models.Character.Character player, Models.Room.Room room,
            InventoryItem itemBeingDropped)
        {
            AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, itemBeingDropped, true);
            player.Attributes.CarriedItemsCount -= itemBeingDropped.InventorySpaceConsumed;
            room.RoomItems.InventoryItems.Add(itemBeingDropped);
            player.CarriedItems.Remove(itemBeingDropped);
        }

        public static void DropWeaponInRoom(Models.Character.Character player, Models.Room.Room room)
        {
            room.RoomItems.WeaponItems.Add(player.WeaponItem);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            player.WeaponItem = new WeaponItem();
        }

        public static void DropWeaponAndPickupNew(Models.Character.Character player, Models.Room.Room room,
            WeaponItem weaponToAddToPlayer)
        {
            room.RoomItems.WeaponItems.Add(player.WeaponItem);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, player.WeaponItem, true);
            AttributeHandler.UpdatePlayerAttributesFromWeaponItem(player, weaponToAddToPlayer);
            weaponToAddToPlayer.InOriginalLocation = false;
            player.WeaponItem = weaponToAddToPlayer;
            room.RoomItems.WeaponItems.Remove(weaponToAddToPlayer);
        }

        public static Items FindAnyMatchingItemsByKeywords(string inputSubstring, List<string> itemKeywords,
            List<InventoryItem> invItemsToSearch, List<WeaponItem> weaponsToSearch)
        {
            if (inputSubstring.Length == 0)
            {
                return null;
            }
            var words = inputSubstring.Split(ConsoleStrings.StringDelimiters);
            foreach (var word in words)
            {
                if (itemKeywords.Contains(word))
                {
                    Items item;
                    foreach (var inventoryItem in invItemsToSearch)
                    {
                        if (inventoryItem.KeywordsForPickup.Contains(word))
                        {
                            item = new Items
                            {
                                InventoryItems = new List<InventoryItem>
                                {
                                    inventoryItem
                                }
                            };
                            return item;
                        }
                    }

                    foreach (var weapon in weaponsToSearch)
                    {
                        if (weapon.KeywordsForPickup.Contains(word))
                        {
                            item = new Items
                            {
                                WeaponItems = new List<WeaponItem>
                                {
                                    weapon
                                }
                            };
                            return item;
                        }
                    }
                }
            }

            return null;
        }

        public static List<string> GetAllInventoryItemKeywords(Models.Character.Character player)
        {
            var keywords = new List<string>();

            if (player?.CarriedItems != null)
            {
                foreach (var item in player.CarriedItems)
                {
                    keywords.AddRange(item.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
                }
            }

            if (!string.IsNullOrEmpty(player?.WeaponItem?.WeaponName))
            {
                keywords.AddRange(player.WeaponItem.KeywordsForPickup.Where(k => !string.IsNullOrEmpty(k)));
            }

            return keywords;
        }

        public static bool HandleItemBeingUsed(Models.Character.Character player, Items foundItem, string playerInput)
        {
            if (foundItem?.WeaponItems?.First() != null)
            {
                Console.WriteLine();
                TypingAnimation.Animate($"You swing your {foundItem.WeaponItems.First().WeaponName} around wildly.\n", Color.ForestGreen);
                return true;
            }

            if (foundItem?.InventoryItems?.First() != null)
            {
                var item = foundItem.InventoryItems.First();
                if (item.TreatItemAs == ItemUseTypes.Default || item.TreatItemAs == ItemUseTypes.Key)
                {
                    Console.WriteLine();
                    TypingAnimation.Animate($"You {playerInput} the {item.ItemName} but nothing happens...\n",
                        Color.ForestGreen);
                    return true;
                }

                if (item.TreatItemAs == ItemUseTypes.Wearable)
                {
                    Console.WriteLine();
                    TypingAnimation.Animate($"You're already wearing the {item.ItemName}...\n", Color.ForestGreen);
                    return true;
                }

                if (item.TreatItemAs == ItemUseTypes.Document)
                {
                    var traitsAdded = "";
                    foreach (var trait in item.ItemTraits)
                    {
                        if (!string.IsNullOrEmpty(trait.RelevantCharacterAttribute))
                        {
                            if (trait.TraitValue > 0)
                            {
                                traitsAdded += $"\n\t{trait.RelevantCharacterAttribute} + ({trait.TraitValue})!";
                                AttributeHandler.AddCharacterAttributesByTrait(player, trait);
                                trait.TraitName = "";
                                trait.TraitValue = 0;
                            }
                        }
                    }

                    Console.WriteLine();
                    TypingAnimation.Animate($"You read the {item.ItemName}: {traitsAdded}\n \n\n{item.DocumentText}\n",
                        Color.GhostWhite);
                    return true;
                }

                if (item.TreatItemAs == ItemUseTypes.ConsumableAttribute)
                {
                    var traitsAdded = "";
                    foreach (var trait in item.ItemTraits)
                    {
                        if (!string.IsNullOrEmpty(trait.RelevantCharacterAttribute))
                        {
                            traitsAdded += $"\n\t{trait.RelevantCharacterAttribute} + ({trait.TraitValue})!";
                            AttributeHandler.AddCharacterAttributesByTrait(player, trait);
                        }
                    }

                    player.Attributes.CarriedItemsCount -= item.InventorySpaceConsumed;
                    player.CarriedItems.Remove(item);
                    Console.WriteLine();
                    TypingAnimation.Animate($"You use the {item.ItemName}: \n{traitsAdded}\n", Color.ForestGreen);
                    return true;
                }

                if (item.TreatItemAs == ItemUseTypes.ConsumableBattery)
                {
                    var flashlight = player.CarriedItems.SingleOrDefault(i =>
                        i.ItemName == ConsoleProgram.ItemCreator.Flashlight.ItemName);
                    var traitsAdded = "";
                    foreach (var trait in item.ItemTraits)
                    {
                        if (!string.IsNullOrEmpty(flashlight?.ItemName))
                        {
                            traitsAdded += $"\n\tFlashlight battery: ({trait.TraitValue}%)!";
                            FlashlightBatteryUpdate.FlashlightBatteryChange(flashlight,
                                percentToSet: trait.TraitValue);
                        }
                    }

                    if (!string.IsNullOrEmpty(flashlight?.ItemName))
                    {
                        player.Attributes.CarriedItemsCount -= item.InventorySpaceConsumed;
                        player.CarriedItems.Remove(item);
                        Console.WriteLine();
                        TypingAnimation.Animate($"You use the {item.ItemName}: \n{traitsAdded}\n", Color.ForestGreen);
                        return true;
                    }

                    Console.WriteLine();
                    TypingAnimation.Animate($"You don't have anything to use the {item.ItemName} on...\n",
                        Color.DarkOliveGreen);
                    return true;
                }

                if (item.TreatItemAs == ItemUseTypes.ConsumableHealth)
                {
                    var traitsAdded = "";
                    if (player.HealthPoints < player.MaximumHealthPoints)
                    {
                        foreach (var trait in item.ItemTraits)
                        {
                            if (string.IsNullOrEmpty(trait.RelevantCharacterAttribute))
                            {
                                if (player.HealthPoints + trait.TraitValue > player.MaximumHealthPoints)
                                {
                                    player.HealthPoints = player.MaximumHealthPoints;
                                }
                                else
                                {
                                    player.HealthPoints += trait.TraitValue;
                                }

                                traitsAdded += $"\n\tHealth Points: + ({trait.TraitValue})!";
                            }
                            else
                            {
                                traitsAdded += trait.TraitValue >= 0 ? $"\n\t{trait.RelevantCharacterAttribute} + ({trait.TraitValue})!" : $"\n\t{trait.RelevantCharacterAttribute} - ({-1 * trait.TraitValue})";
                                AttributeHandler.AddCharacterAttributesByTrait(player, trait);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(traitsAdded))
                    {
                        player.Attributes.CarriedItemsCount -= item.InventorySpaceConsumed;
                        player.CarriedItems.Remove(item);
                        Console.WriteLine();
                        TypingAnimation.Animate($"You consume the {item.ItemName}: \n{traitsAdded}\n",
                            Color.ForestGreen);
                        return true;
                    }

                    Console.WriteLine();
                    TypingAnimation.Animate(
                        $"You don't need to use the {item.ItemName}, you have full Health Points...\n",
                        Color.DarkOliveGreen);
                    return true;
                }

                if (item.TreatItemAs == ItemUseTypes.ConsumableAmmo)
                {
                    var traitsAdded = "";

                    if (!string.IsNullOrEmpty(player.WeaponItem?.WeaponName)
                        && !string.IsNullOrEmpty(player.WeaponItem?.AmmunitionType)
                        && player.WeaponItem.AmmunitionType == item.AmmunitionType)
                    {
                        player.WeaponItem.AmmunitionAmount += item.AmmunitionAmount;
                        traitsAdded += $"\n\t{player.WeaponItem.WeaponName} Ammo + ({item.AmmunitionAmount}) = ({player.WeaponItem.AmmunitionAmount})!";
                        player.Attributes.CarriedItemsCount -= item.InventorySpaceConsumed;
                        player.CarriedItems.Remove(item);
                        Console.WriteLine();
                        TypingAnimation.Animate($"You use the {item.ItemName}: \n{traitsAdded}\n", Color.ForestGreen);
                        return true;
                    }

                    Console.WriteLine();
                    TypingAnimation.Animate($"You don't have a weapon that uses {item.AmmunitionType}...\n",
                        Color.DarkOliveGreen);
                    return true;
                }
            }

            return false;
        }

        public static bool HandlePlayerTradingItem(string fullInput, Models.Character.Character player, Models.Room.Room currentRoom, 
            string inputWord, bool inputResolved)
        {
            if (currentRoom.RoomCharacters.Any())
            {
                var substring = PlayerActionHandler.CreateSubstringOfActionInput(fullInput, inputWord);
                var character =
                    RoomHandler.FindAnyMatchingCharacterByKeywords(substring.Trim(), currentRoom);
                var inventoryKeywords = GetAllInventoryItemKeywords(player);
                var foundItem = FindAnyMatchingItemsByKeywords(substring.Trim(), inventoryKeywords,
                    player.CarriedItems, new List<WeaponItem> { player.WeaponItem });
                if (foundItem != null && character != null)
                {
                    if (GiveItemIsOk(player, character, foundItem))
                    {
                        var tradedItem = HandleItemTrade(player, character, foundItem, currentRoom);
                        if (!string.IsNullOrEmpty(tradedItem.ItemName))
                        {
                            TypingAnimation.Animate("\nYou give the " + foundItem.InventoryItems.First().ItemName + " to " + 
                                                    character.Name + ".\n" + character.Name + " gives you the " + tradedItem.ItemName + ".\n", Color.Gold);
                        }
                        else
                        {
                            TypingAnimation.Animate("Your inventory is full... You cannot take the " + 
                                                    tradedItem.ItemName + ".\n", Color.DarkOliveGreen);
                        }

                        inputResolved = true;
                    }
                    else
                    {
                        Colorful.Console.WriteLine();
                        TypingAnimation.Animate(character.Name + " doesn't want that item.\n", Color.DarkOliveGreen);
                        inputResolved = true;
                    }
                }
            }
            else
            {
                Colorful.Console.WriteLine("\nThere is no one here to give that to...", Color.DarkOliveGreen);
                inputResolved = true;
            }

            return inputResolved;
        }

        public static bool GiveItemIsOk(Models.Character.Character player, Models.Character.Character character, Items foundItem)
        {
            if (foundItem.InventoryItems.Any())
            {
                return character.DesiredItem != null
                       && character.DesiredItem.ItemName == foundItem.InventoryItems.First().ItemName;
            }

            return false;
        }

        public static InventoryItem HandleItemTrade(Models.Character.Character player, Models.Character.Character character, Items foundItem, Models.Room.Room currentRoom)
        {
            if (foundItem.InventoryItems.Any())
            {
                AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, foundItem.InventoryItems.First(), true);
                player.Attributes.CarriedItemsCount -= foundItem.InventoryItems.First().InventorySpaceConsumed;
                character.CarriedItems.Add(foundItem.InventoryItems.First());
                player.CarriedItems.Remove(foundItem.InventoryItems.First());

                if (character.DesiredItem != null
                    && player.Attributes.CarriedItemsCount + character.OfferedItem.InventorySpaceConsumed <= player.Attributes.MaximumCarryingCapacity)
                {
                    AttributeHandler.UpdatePlayerAttributesFromInventoryItem(player, character.OfferedItem);
                    player.Attributes.CarriedItemsCount += character.OfferedItem.InventorySpaceConsumed;
                    player.CarriedItems.Add(character.OfferedItem);
                    character.CarriedItems.Remove(character.OfferedItem);
                    character.DesiredItem = new InventoryItem();
                    return character.OfferedItem;
                }
            }

            return new InventoryItem { ItemName = "" };
        }
    }
}
