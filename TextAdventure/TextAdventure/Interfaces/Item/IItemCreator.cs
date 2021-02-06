﻿using TextAdventure.Models.Item;

namespace TextAdventure.Interfaces.Item
{
    public interface IItemCreator
    {
        // Declare all getters for any Items you will use here
        InventoryItem Bathrobe { get; }
        InventoryItem Flashlight { get; }
        InventoryItem RunningShoes { get; }
        InventoryItem TinyBackpack { get; }
        InventoryItem PlainBagel { get; }
        InventoryItem StrangeCreaturesBook { get; }
        InventoryItem FlashlightBattery { get; }
        InventoryItem DirtyLetter { get; }
        InventoryItem Newspaper { get; }
        InventoryItem ScotchWhiskey { get; }
        InventoryItem CanvasBookBag { get; }
        InventoryItem DirtyGoldBullet { get; }
        InventoryItem WornLeatherBoots { get; }
        InventoryItem RabbitsFoot { get; }
        InventoryItem StrangeThermos { get; }
        InventoryItem AbandonedFlashlightBattery { get; }
        InventoryItem TownCurfewNotice { get; }
        InventoryItem HumanTeeth { get; }
        InventoryItem WomansNecklace { get; }
        InventoryItem BloodyJeans { get; }
        InventoryItem LuckyBrandChewingGum { get; }
        InventoryItem HuntingCap { get; }
        InventoryItem MangledBallCap { get; }
        InventoryItem PlatinumRing { get; }
        InventoryItem SomberNote { get; }
        InventoryItem TownSouthGateKey { get; }
        InventoryItem EnergyBar { get; }
        InventoryItem BottleOfScentMask { get; }
        InventoryItem BoxOf44MagnumAmmo { get; }
        InventoryItem WetGoldBullet { get; }
        InventoryItem MiracleTonic { get; }
        InventoryItem SnakeBracelet { get; }
        InventoryItem WaterloggedJournal { get; }
        InventoryItem BloodyGoldBullet { get; }
        InventoryItem BomberJacket { get; }
        InventoryItem BoxOfShotgunShells { get; }
        InventoryItem LargeKnapsack { get; }
        InventoryItem CannedMeat { get; }
        InventoryItem TownNorthGateKey { get; }
        InventoryItem GoldWristwatch { get; }
        InventoryItem TownWestGateKey { get; }
        InventoryItem WestForestNotice { get; }
        InventoryItem TownEastGateKey { get; }
        InventoryItem Crowbar { get; }
        InventoryItem ToyBoat { get; }
        InventoryItem BottleOfRum { get; }
        InventoryItem SteelToedBoots { get; }
        InventoryItem BrandNewFlashlightBattery { get; }
        InventoryItem TownDurrowHouseKey { get; }
        InventoryItem ForestGreenCargoPants { get; }
        InventoryItem ChildsDrawing { get; }
        InventoryItem NoteToRobertDurrow { get; }

        // Missing Person Posters
        InventoryItem MissingPersonPosterLucy { get; }
        InventoryItem MissingPersonPosterPenny { get; }
        InventoryItem MissingPersonPosterSimon { get; }
        InventoryItem MissingPersonPosterArthur { get; }
        InventoryItem MissingPersonPosterDuncan { get; }

        // Declare all getters for any Weapons you will use here
        WeaponItem LetterOpener { get; }
        WeaponItem BaseballBat { get; }
        WeaponItem Femur { get; }
        WeaponItem LumberAxe { get; }
        WeaponItem FiremansAxe { get; }
        WeaponItem MagnumRevolver { get; }
        WeaponItem Shotgun { get; }
        WeaponItem GhoulRifle { get; }
        WeaponItem GhoulClaws { get; }
    }
}
