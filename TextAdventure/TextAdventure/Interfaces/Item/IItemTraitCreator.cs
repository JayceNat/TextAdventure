using TextAdventure.Models.Item;

namespace TextAdventure.Interfaces.Item
{
    public interface IItemTraitCreator
    {
        ItemTrait BatteryPercentage(int percent);

        ItemTrait BatteryItem(int newBatteryPercent);

        ItemTrait HealthItem(int healthRestored);

        ItemTrait ConsumedAttributeItem(string relevantAttribute, int traitValue);

        ItemTrait CarriedItemsIncrease(int amount);

        ItemTrait CarryingCapacityIncrease(int amount);

        ItemTrait DefenseIncrease(int amount);

        ItemTrait DexterityIncrease(int amount);

        ItemTrait LuckIncrease(int amount);

        ItemTrait StaminaIncrease(int amount);

        ItemTrait StrengthIncrease(int amount);

        ItemTrait WisdomIncrease(int amount);
    }
}
