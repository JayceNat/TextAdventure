namespace TextAdventure.Interfaces.Room
{
    public interface IRoomCreator
    {
        // Files to edit when adding a room: GameRooms.cs, RoomCreator.cs, GameSetupHandler.cs
        // Declare all getters for any Rooms you will use here

        // Your House
        Models.Room.Room YourBedroom { get; set; }
        Models.Room.Room YourLivingRoom { get; set; }
        Models.Room.Room YourKitchen { get; set; }
        Models.Room.Room YourFrontEntryway { get; set; }
        Models.Room.Room YourBasement { get; set; }
        Models.Room.Room YourFrontPorch { get; set; }
        Models.Room.Room YourDriveway { get; set; }
        Models.Room.Room YourShed { get; set; }
        Models.Room.Room RoadConnectingYourHouseToTown { get; set; }

        // Forest
        Models.Room.Room ForestLake { get; set; }
        Models.Room.Room ForestLakeTent { get; set; }
        Models.Room.Room EastForest { get; set; }
        Models.Room.Room EastForestLowerClearing { get; set; }
        Models.Room.Room EastForestUpperClearing { get; set; }
        Models.Room.Room DeepEastForest { get; set; }
        Models.Room.Room DeepEastForestLowerRiver { get; set; }
        Models.Room.Room DeepEastForestUpperRiver { get; set; }
        Models.Room.Room DeepEastForestUpperRiverCave { get; set; }
        Models.Room.Room EastForestCampground { get; set; }
        Models.Room.Room PathBetweenCampAndEastRoad { get; set; }
        Models.Room.Room EastRoadToTown { get; set; }

        // Town
        Models.Room.Room TownSouthEntrance { get; set; }
        Models.Room.Room TownNorthEntrance { get; set; }
        Models.Room.Room TownEastEntrance { get; set; }
        Models.Room.Room TownWestEntrance { get; set; }
        Models.Room.Room AshburySouthSquare { get; set; }
        Models.Room.Room AshburyNorthSquare { get; set; }
        Models.Room.Room AshburyEastSquare { get; set; }
        Models.Room.Room AshburyWestSquare { get; set; }
        Models.Room.Room AshburySouthMainStreet { get; set; }
        Models.Room.Room AshburyNorthMainStreet { get; set; }
        Models.Room.Room AshburyEastPlaza { get; set; }
        Models.Room.Room AshburyWestPlaza { get; set; }
        Models.Room.Room AshburyTownCenter { get; set; }
        Models.Room.Room AshburySouthSquareEastAlley { get; set; }
        Models.Room.Room AshburySouthEastVeterinaryClinic { get; set; }
        Models.Room.Room AshburySouthEastCornerLot { get; set; }
        Models.Room.Room AshburySouthEastDurrowHouse { get; set; }
        Models.Room.Room AshburySouthEastAviary { get; set; }
        Models.Room.Room AshburySouthEastWell { get; set; }
        Models.Room.Room AshburySouthSquareWestAlley { get; set; }

        // Helpers to avoid circular dependency during compilation and serialization
        void AddExitsToAllRooms();
        void RemoveExitsFromAllRooms();
    }
}
