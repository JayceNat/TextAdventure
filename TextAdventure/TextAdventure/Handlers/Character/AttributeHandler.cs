﻿using TextAdventure.Constants.Character;
using TextAdventure.Constants.Item;
using TextAdventure.Models.Item;

namespace TextAdventure.Handlers.Character
{
    public class AttributeHandler
    {
        // When a user picks up or drops an inventory item, adjusts their attributes accordingly
        public static void UpdatePlayerAttributesFromInventoryItem(Models.Character.Character player,
            InventoryItem newInventoryItem, bool removeAttributes = false)
        {
            if (newInventoryItem?.ItemTraits == null
                || newInventoryItem.TreatItemAs == ItemUseTypes.ConsumableAttribute
                || newInventoryItem.TreatItemAs == ItemUseTypes.ConsumableAmmo
                || newInventoryItem.TreatItemAs == ItemUseTypes.ConsumableHealth
                || newInventoryItem.TreatItemAs == ItemUseTypes.Document
                || newInventoryItem.TreatItemAs == ItemUseTypes.Key) return;
            foreach (var trait in newInventoryItem.ItemTraits)
            {
                if (removeAttributes)
                {
                    RemoveCharacterAttributesByTrait(player, trait);
                }
                else
                {
                    AddCharacterAttributesByTrait(player, trait);
                }
            }
        }

        // When a user picks up or drops a weapon item, adjusts their attributes accordingly
        public static void UpdatePlayerAttributesFromWeaponItem(Models.Character.Character player, WeaponItem newWeaponItem, bool removeAttributes = false)
        {
            if (newWeaponItem?.WeaponTraits == null) return;
            foreach (var trait in newWeaponItem.WeaponTraits)
            {
                if (removeAttributes)
                {
                    RemoveCharacterAttributesByTrait(player, trait);
                }
                else
                {
                    AddCharacterAttributesByTrait(player, trait);
                }
            }
        }

        // Helper used by the two methods above
        public static void AddCharacterAttributesByTrait(Models.Character.Character player, ItemTrait trait)
        {

            switch (trait.RelevantCharacterAttribute)
            {
                case AttributeStrings.Defense:
                    player.Attributes.Defense += trait.TraitValue;
                    break;
                case AttributeStrings.Dexterity:
                    player.Attributes.Dexterity += trait.TraitValue;
                    break;
                case AttributeStrings.Luck:
                    player.Attributes.Luck += trait.TraitValue;
                    break;
                case AttributeStrings.Stamina:
                    player.Attributes.Stamina += trait.TraitValue;
                    player.MaximumHealthPoints += CharacterDefaults.HealthPerStaminaPointIncrease * trait.TraitValue;
                    player.HealthPoints += CharacterDefaults.HealthPerStaminaPointIncrease * trait.TraitValue;
                    break;
                case AttributeStrings.Strength:
                    player.Attributes.Strength += trait.TraitValue;
                    break;
                case AttributeStrings.Wisdom:
                    player.Attributes.Wisdom += trait.TraitValue;
                    break;
                case AttributeStrings.MaxCarryingCapacity:
                    player.Attributes.MaximumCarryingCapacity += trait.TraitValue;
                    break;
            }
        }

        // Helper used by the two methods above
        public static void RemoveCharacterAttributesByTrait(Models.Character.Character player, ItemTrait trait)
        {
            switch (trait.RelevantCharacterAttribute)
            {
                case AttributeStrings.Defense:
                    player.Attributes.Defense -= trait.TraitValue;
                    break;
                case AttributeStrings.Dexterity:
                    player.Attributes.Dexterity -= trait.TraitValue;
                    break;
                case AttributeStrings.Luck:
                    player.Attributes.Luck -= trait.TraitValue;
                    break;
                case AttributeStrings.Stamina:
                    player.Attributes.Stamina -= trait.TraitValue;
                    player.MaximumHealthPoints -= CharacterDefaults.HealthPerStaminaPointIncrease * trait.TraitValue;
                    player.HealthPoints -= CharacterDefaults.HealthPerStaminaPointIncrease * trait.TraitValue;
                    break;
                case AttributeStrings.Strength:
                    player.Attributes.Strength -= trait.TraitValue;
                    break;
                case AttributeStrings.Wisdom:
                    player.Attributes.Wisdom -= trait.TraitValue;
                    break;
                case AttributeStrings.MaxCarryingCapacity:
                    player.Attributes.MaximumCarryingCapacity -= trait.TraitValue;
                    break;
            }
        }
    }
}
