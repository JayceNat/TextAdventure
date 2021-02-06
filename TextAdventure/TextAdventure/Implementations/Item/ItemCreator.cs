using TextAdventure.Interfaces.Item;
using TextAdventure.Models.Item;
using Items = TextAdventure.GameEntities.Item.Items;
using Weapons = TextAdventure.GameEntities.Item.Weapons;

namespace TextAdventure.Implementations.Item
{
    public class ItemCreator : IItemCreator
    {
        // Declare all getters for any Items you will use here
        public InventoryItem Bathrobe { get; }
        public InventoryItem Flashlight { get; }
        public InventoryItem RunningShoes { get; }
        public InventoryItem TinyBackpack { get; }
        public InventoryItem PlainBagel { get; }
        public InventoryItem StrangeCreaturesBook { get; }
        public InventoryItem FlashlightBattery { get; }
        public InventoryItem DirtyLetter { get; }
        public InventoryItem Newspaper { get; }
        public InventoryItem ScotchWhiskey { get; }
        public InventoryItem CanvasBookBag { get; }
        public InventoryItem DirtyGoldBullet { get; }
        public InventoryItem WornLeatherBoots { get; }
        public InventoryItem RabbitsFoot { get; }
        public InventoryItem StrangeThermos { get; }
        public InventoryItem AbandonedFlashlightBattery { get; }
        public InventoryItem TownCurfewNotice { get; }
        public InventoryItem HumanTeeth { get; }
        public InventoryItem WomansNecklace { get; }
        public InventoryItem BloodyJeans { get; }
        public InventoryItem LuckyBrandChewingGum { get; }
        public InventoryItem HuntingCap { get; }
        public InventoryItem MangledBallCap { get; }
        public InventoryItem PlatinumRing { get; }
        public InventoryItem SomberNote { get; }
        public InventoryItem TownSouthGateKey { get; }
        public InventoryItem EnergyBar { get; }
        public InventoryItem BottleOfScentMask { get; }
        public InventoryItem BoxOf44MagnumAmmo { get; }
        public InventoryItem WetGoldBullet { get; }
        public InventoryItem MiracleTonic { get; }
        public InventoryItem SnakeBracelet { get; }
        public InventoryItem WaterloggedJournal { get; }
        public InventoryItem BloodyGoldBullet { get; }
        public InventoryItem BomberJacket { get; }
        public InventoryItem BoxOfShotgunShells { get; }
        public InventoryItem LargeKnapsack { get; }
        public InventoryItem CannedMeat { get; }
        public InventoryItem TownNorthGateKey { get; }
        public InventoryItem GoldWristwatch { get; }
        public InventoryItem TownWestGateKey { get; }
        public InventoryItem WestForestNotice { get; }
        public InventoryItem TownEastGateKey { get; }
        public InventoryItem Crowbar { get; }
        public InventoryItem ToyBoat { get; }
        public InventoryItem BottleOfRum { get; }
        public InventoryItem SteelToedBoots { get; }
        public InventoryItem BrandNewFlashlightBattery { get; }
        public InventoryItem TownDurrowHouseKey { get; }
        public InventoryItem ForestGreenCargoPants { get; }
        public InventoryItem ChildsDrawing { get; }
        public InventoryItem NoteToRobertDurrow { get; }

        // Missing Person Posters
        public InventoryItem MissingPersonPosterLucy { get; }
        public InventoryItem MissingPersonPosterPenny { get; }
        public InventoryItem MissingPersonPosterSimon { get; }
        public InventoryItem MissingPersonPosterArthur { get; }
        public InventoryItem MissingPersonPosterDuncan { get; }

        // Declare all getters for any Weapons you will use here
        public WeaponItem LetterOpener { get; }
        public WeaponItem BaseballBat { get; }
        public WeaponItem Femur { get; }
        public WeaponItem LumberAxe { get; }
        public WeaponItem FiremansAxe { get; }
        public WeaponItem MagnumRevolver { get; }
        public WeaponItem Shotgun { get; }
        public WeaponItem GhoulRifle { get; }
        public WeaponItem GhoulClaws { get; }

        // Constructor: Add the reference to all the Item/Weapon Objects here
        public ItemCreator()
        {
            // Inventory Items
            Bathrobe = Items.Bathrobe;
            Flashlight = Items.Flashlight;
            RunningShoes = Items.RunningShoes;
            TinyBackpack = Items.TinyBackpack;
            PlainBagel = Items.PlainBagel;
            StrangeCreaturesBook = Items.StrangeCreaturesBook;
            FlashlightBattery = Items.OldFlashlightBattery;
            DirtyLetter = Items.DirtyLetter;
            Newspaper = Items.Newspaper;
            ScotchWhiskey = Items.ScotchWhiskey;
            CanvasBookBag = Items.CanvasBookBag;
            DirtyGoldBullet = Items.DirtyGoldBullet;
            WornLeatherBoots = Items.WornLeatherBoots;
            RabbitsFoot = Items.RabbitsFoot;
            StrangeThermos = Items.StrangeThermos;
            AbandonedFlashlightBattery = Items.AbandonedFlashlightBattery;
            TownCurfewNotice = Items.TownCurfewNotice;
            HumanTeeth = Items.HumanTeeth;
            WomansNecklace = Items.WomansNecklace;
            BloodyJeans = Items.BloodyJeans;
            LuckyBrandChewingGum = Items.LuckyBrandChewingGum;
            HuntingCap = Items.HuntingCap;
            MangledBallCap = Items.MangledBallCap;
            PlatinumRing = Items.PlatinumRing;
            SomberNote = Items.SomberNote;
            TownSouthGateKey = Items.TownSouthGateKey;
            EnergyBar = Items.EnergyBar;
            BottleOfScentMask = Items.BottleOfScentMask;
            BoxOf44MagnumAmmo = Items.BoxOf44MagnumAmmo;
            WetGoldBullet = Items.MuddyGoldBullet;
            MiracleTonic = Items.MiracleTonic;
            SnakeBracelet = Items.SnakeBracelet;
            WaterloggedJournal = Items.WaterloggedJournal;
            BloodyGoldBullet = Items.BloodyGoldBullet;
            BomberJacket = Items.BomberJacket;
            BoxOfShotgunShells = Items.BoxOfShotgunShells;
            LargeKnapsack = Items.LargeKnapsack;
            CannedMeat = Items.CannedMeat;
            TownNorthGateKey = Items.TownNorthGateKey;
            TownEastGateKey = Items.TownEastGateKey;
            TownWestGateKey = Items.TownWestGateKey;
            GoldWristwatch = Items.GoldWristwatch;
            WestForestNotice = Items.WestForestNotice;
            Crowbar = Items.Crowbar;
            ToyBoat = Items.ToyBoat;
            BottleOfRum = Items.BottleOfRum;
            SteelToedBoots = Items.SteelToedBoots;
            TownDurrowHouseKey = Items.TownDurrowHouseKey;
            ForestGreenCargoPants = Items.ForestGreenCargoPants;
            ChildsDrawing = Items.ChildsDrawing;
            NoteToRobertDurrow = Items.NoteToRobertDurrow;
            BrandNewFlashlightBattery = Items.BrandNewFlashlightBattery;
            MissingPersonPosterLucy = Items.MissingPersonPosterLucy;
            MissingPersonPosterPenny = Items.MissingPersonPosterPenny;
            MissingPersonPosterSimon = Items.MissingPersonPosterSimon;
            MissingPersonPosterArthur = Items.MissingPersonPosterArthur;
            MissingPersonPosterDuncan = Items.MissingPersonPosterDuncan;

            // Weapon Items
            LetterOpener = Weapons.LetterOpener;
            BaseballBat = Weapons.BaseballBat;
            Femur = Weapons.Femur;
            LumberAxe = Weapons.LumberAxe;
            FiremansAxe = Weapons.FiremansAxe;
            MagnumRevolver = Weapons.MagnumRevolver;
            Shotgun = Weapons.Shotgun;
            GhoulRifle = Weapons.GhoulRifle;
            GhoulClaws = Weapons.GhoulClaws;
        }
    }
}
