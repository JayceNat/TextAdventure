﻿using System.Collections.Generic;
using TextAdventure.Models.Item;

namespace TextAdventure.Utilities
{
    public class FlashlightBatteryUpdate
    {
        public static bool FlashlightBatteryChange(InventoryItem item, int percentBefore = 0, int percentToReduce = 0, int percentToSet = -1)
        {
            if (percentToSet > -1)
            {
                item.ItemTraits = new List<ItemTrait>
                {
                    ConsoleProgram.ItemTraitCreator.BatteryPercentage(percentToSet)
                };
            }
            else if (percentToReduce > 0)
            {
                if (percentBefore - percentToReduce < 0)
                {
                    item.ItemTraits = new List<ItemTrait>
                    {
                        ConsoleProgram.ItemTraitCreator.BatteryPercentage(0)
                    };
                    return false;
                }

                item.ItemTraits = new List<ItemTrait>
                {
                    ConsoleProgram.ItemTraitCreator.BatteryPercentage(percentBefore - percentToReduce)
                };
            }

            return true;
        }
    }
}
