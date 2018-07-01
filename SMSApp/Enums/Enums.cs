namespace SMSApp.Enums
{
    public enum Entities
    {
        Diseases,
        Pests,
        Plants,
        Contagions,
        FarmOwners
    }

    public enum MessageStatuses
    {
        NotReceived,
        Received,
        Visited,
        Reacted,
        NotReacted
    }

    public enum BroadcastWarningLevels
    {
        NoThreat,
        LowThreat,
        ModerateThreat,
        HighThreat,
        HighestThreat
    }

    public enum UserPermissions
    {
        CanUpdateUsers=1,
        CanReadEntities=2,
        CanUpdateEntities=4,
        CanSendBroadcasts=8,
        CanPrintReports=16
    }

    public enum DangerRating
    {
        Low,
        Moderate,
        High,
        Higest
    }

    public enum PlantGrowthStatus
    {
        Seed,
        Sprout,
        Seedling,
        Vegetative,
        Budding,
        Flowering,
        Ripening,
        Harvesting,
        Harvested
    }

    public enum Seasons
    {
        Winter,
        Spring,
        Summer,
        Fall
    }
}