namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Broadcasts",
                c => new
                    {
                        BroadcastId = c.Int(nullable: false, identity: true),
                        MessageText = c.String(nullable: false, storeType: "ntext"),
                        WarningLevel = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ContagionId = c.Int(),
                        FarmOwner_FarmOwnerId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.BroadcastId)
                .ForeignKey("dbo.Contagions", t => t.ContagionId)
                .ForeignKey("dbo.FarmOwners", t => t.FarmOwner_FarmOwnerId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.ContagionId)
                .Index(t => t.FarmOwner_FarmOwnerId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Contagions",
                c => new
                    {
                        ContagionId = c.Int(nullable: false, identity: true),
                        DamageInMoney = c.Single(nullable: false),
                        DamageInCropVolume = c.Single(nullable: false),
                        DamageInPercentage = c.Single(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        FarmPlantId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ContagionId)
                .ForeignKey("dbo.FarmPlants", t => t.FarmPlantId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.FarmPlantId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Diseases",
                c => new
                    {
                        DiseaseId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ScientificName = c.String(),
                        AgriculturalName = c.String(),
                        ScientificClassification = c.String(),
                        AgriculturalClassification = c.String(),
                        Risks = c.String(storeType: "ntext"),
                        DangerRating = c.Int(nullable: false),
                        SpeedOfTransmission = c.String(),
                        Vaccinations = c.String(storeType: "ntext"),
                        Diagnostics = c.String(storeType: "ntext"),
                        ChemicalTreatment = c.String(storeType: "ntext"),
                        NonChemicalTreatment = c.String(storeType: "ntext"),
                        Prognosis = c.String(storeType: "ntext"),
                        Lifespan = c.String(),
                        AdditionalNotes = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.DiseaseId);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(storeType: "ntext"),
                        URL = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        FarmOwnerId = c.Int(),
                        PlantId = c.Int(),
                        DiseaseId = c.Int(),
                        PestId = c.Int(),
                        ContagionId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Contagions", t => t.ContagionId)
                .ForeignKey("dbo.Diseases", t => t.DiseaseId)
                .ForeignKey("dbo.FarmOwners", t => t.FarmOwnerId)
                .ForeignKey("dbo.Pests", t => t.PestId)
                .ForeignKey("dbo.Plants", t => t.PlantId)
                .Index(t => t.FarmOwnerId)
                .Index(t => t.PlantId)
                .Index(t => t.DiseaseId)
                .Index(t => t.PestId)
                .Index(t => t.ContagionId);
            
            CreateTable(
                "dbo.FarmOwners",
                c => new
                    {
                        FarmOwnerId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        PassportNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        MobilePhone1 = c.String(nullable: false),
                        MobilePhone2 = c.String(),
                        HomePhone1 = c.String(nullable: false),
                        HomePhone2 = c.String(),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FarmOwnerId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Farms",
                c => new
                    {
                        FarmId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        City = c.String(),
                        Region = c.String(),
                        RegistrationCertificateNum = c.String(),
                        EstablishedYear = c.DateTime(nullable: false),
                        Area = c.Single(nullable: false),
                        IndustryType = c.String(),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        LogoUrl = c.String(),
                        FarmOwnerId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.FarmId)
                .ForeignKey("dbo.FarmOwners", t => t.FarmOwnerId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.FarmOwnerId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Geopositions",
                c => new
                    {
                        GeopositionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        GeoData = c.String(storeType: "ntext"),
                        Area = c.Single(nullable: false),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        FarmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeopositionId)
                .ForeignKey("dbo.Farms", t => t.FarmId)
                .Index(t => t.FarmId);
            
            CreateTable(
                "dbo.SoilReadings",
                c => new
                    {
                        SoilReadingId = c.Int(nullable: false, identity: true),
                        HumusLevel = c.Single(nullable: false),
                        PottasiumLevel = c.Single(nullable: false),
                        PhosphorusLevel = c.Single(nullable: false),
                        NitrateLevel = c.Single(nullable: false),
                        AcidityLevel = c.Single(nullable: false),
                        SoilFertilityRating = c.Single(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        GeopositionId = c.Int(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.SoilReadingId)
                .ForeignKey("dbo.Geopositions", t => t.GeopositionId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.GeopositionId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Pests",
                c => new
                    {
                        PestId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ScientificName = c.String(),
                        AgriculturalName = c.String(),
                        ScientificClassification = c.String(),
                        AgriculturalClassification = c.String(),
                        Risks = c.String(storeType: "ntext"),
                        DangerRating = c.Int(nullable: false),
                        SpeedOfGrowth = c.String(),
                        Prevention = c.String(storeType: "ntext"),
                        Detection = c.String(storeType: "ntext"),
                        ChemicalTreatment = c.String(storeType: "ntext"),
                        NonChemicalTreatment = c.String(storeType: "ntext"),
                        Prognosis = c.String(storeType: "ntext"),
                        Lifespan = c.String(),
                        AdditionalNotes = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.PestId);
            
            CreateTable(
                "dbo.Plants",
                c => new
                    {
                        PlantId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ScientificName = c.String(),
                        AgriculturalName = c.String(),
                        VendorCode = c.String(),
                        IAPTCode = c.String(),
                        AgriculturalClassification = c.String(),
                        ScientificClassification = c.String(),
                        Vendor = c.String(),
                        CountryOfOrigin = c.String(),
                        Lifespan = c.String(),
                        IconUrl = c.String(),
                        AdditionalNotes = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.PlantId);
            
            CreateTable(
                "dbo.FarmPlants",
                c => new
                    {
                        FarmPlantId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Season = c.Int(nullable: false),
                        GrowthStatus = c.Int(nullable: false),
                        ExpectedYield = c.Double(nullable: false),
                        InitialInvestment = c.Double(nullable: false),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        GeopositionId = c.Int(),
                        PlantId = c.Int(),
                    })
                .PrimaryKey(t => t.FarmPlantId)
                .ForeignKey("dbo.Geopositions", t => t.GeopositionId)
                .ForeignKey("dbo.Plants", t => t.PlantId)
                .Index(t => new { t.GeopositionId, t.PlantId, t.Year, t.Season }, unique: true, name: "IX_UniqueFarmPlant");
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Feedback = c.String(storeType: "ntext"),
                        MessageText = c.String(nullable: false, storeType: "ntext"),
                        Date = c.DateTime(nullable: false),
                        BroadcastId = c.Int(),
                        FarmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Broadcasts", t => t.BroadcastId)
                .ForeignKey("dbo.Farms", t => t.FarmId, cascadeDelete: true)
                .Index(t => new { t.BroadcastId, t.FarmId }, unique: true, name: "IX_UniqueMessage");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(),
                        Permissions = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.DiseaseContagions",
                c => new
                    {
                        Disease_DiseaseId = c.Int(nullable: false),
                        Contagion_ContagionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disease_DiseaseId, t.Contagion_ContagionId })
                .ForeignKey("dbo.Diseases", t => t.Disease_DiseaseId, cascadeDelete: true)
                .ForeignKey("dbo.Contagions", t => t.Contagion_ContagionId, cascadeDelete: true)
                .Index(t => t.Disease_DiseaseId)
                .Index(t => t.Contagion_ContagionId);
            
            CreateTable(
                "dbo.PestContagions",
                c => new
                    {
                        Pest_PestId = c.Int(nullable: false),
                        Contagion_ContagionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pest_PestId, t.Contagion_ContagionId })
                .ForeignKey("dbo.Pests", t => t.Pest_PestId, cascadeDelete: true)
                .ForeignKey("dbo.Contagions", t => t.Contagion_ContagionId, cascadeDelete: true)
                .Index(t => t.Pest_PestId)
                .Index(t => t.Contagion_ContagionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SoilReadings", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Farms", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.FarmOwners", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Contagions", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Broadcasts", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "FarmId", "dbo.Farms");
            DropForeignKey("dbo.Messages", "BroadcastId", "dbo.Broadcasts");
            DropForeignKey("dbo.FarmPlants", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.FarmPlants", "GeopositionId", "dbo.Geopositions");
            DropForeignKey("dbo.Contagions", "FarmPlantId", "dbo.FarmPlants");
            DropForeignKey("dbo.Photos", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Photos", "PestId", "dbo.Pests");
            DropForeignKey("dbo.PestContagions", "Contagion_ContagionId", "dbo.Contagions");
            DropForeignKey("dbo.PestContagions", "Pest_PestId", "dbo.Pests");
            DropForeignKey("dbo.Photos", "FarmOwnerId", "dbo.FarmOwners");
            DropForeignKey("dbo.SoilReadings", "GeopositionId", "dbo.Geopositions");
            DropForeignKey("dbo.Geopositions", "FarmId", "dbo.Farms");
            DropForeignKey("dbo.Farms", "FarmOwnerId", "dbo.FarmOwners");
            DropForeignKey("dbo.Broadcasts", "FarmOwner_FarmOwnerId", "dbo.FarmOwners");
            DropForeignKey("dbo.Photos", "DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.Photos", "ContagionId", "dbo.Contagions");
            DropForeignKey("dbo.DiseaseContagions", "Contagion_ContagionId", "dbo.Contagions");
            DropForeignKey("dbo.DiseaseContagions", "Disease_DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.Broadcasts", "ContagionId", "dbo.Contagions");
            DropIndex("dbo.PestContagions", new[] { "Contagion_ContagionId" });
            DropIndex("dbo.PestContagions", new[] { "Pest_PestId" });
            DropIndex("dbo.DiseaseContagions", new[] { "Contagion_ContagionId" });
            DropIndex("dbo.DiseaseContagions", new[] { "Disease_DiseaseId" });
            DropIndex("dbo.Messages", "IX_UniqueMessage");
            DropIndex("dbo.FarmPlants", "IX_UniqueFarmPlant");
            DropIndex("dbo.SoilReadings", new[] { "User_UserId" });
            DropIndex("dbo.SoilReadings", new[] { "GeopositionId" });
            DropIndex("dbo.Geopositions", new[] { "FarmId" });
            DropIndex("dbo.Farms", new[] { "User_UserId" });
            DropIndex("dbo.Farms", new[] { "FarmOwnerId" });
            DropIndex("dbo.FarmOwners", new[] { "User_UserId" });
            DropIndex("dbo.Photos", new[] { "ContagionId" });
            DropIndex("dbo.Photos", new[] { "PestId" });
            DropIndex("dbo.Photos", new[] { "DiseaseId" });
            DropIndex("dbo.Photos", new[] { "PlantId" });
            DropIndex("dbo.Photos", new[] { "FarmOwnerId" });
            DropIndex("dbo.Contagions", new[] { "User_UserId" });
            DropIndex("dbo.Contagions", new[] { "FarmPlantId" });
            DropIndex("dbo.Broadcasts", new[] { "User_UserId" });
            DropIndex("dbo.Broadcasts", new[] { "FarmOwner_FarmOwnerId" });
            DropIndex("dbo.Broadcasts", new[] { "ContagionId" });
            DropTable("dbo.PestContagions");
            DropTable("dbo.DiseaseContagions");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.FarmPlants");
            DropTable("dbo.Plants");
            DropTable("dbo.Pests");
            DropTable("dbo.SoilReadings");
            DropTable("dbo.Geopositions");
            DropTable("dbo.Farms");
            DropTable("dbo.FarmOwners");
            DropTable("dbo.Photos");
            DropTable("dbo.Diseases");
            DropTable("dbo.Contagions");
            DropTable("dbo.Broadcasts");
        }
    }
}
