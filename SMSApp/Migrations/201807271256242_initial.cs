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
                        UserId = c.Int(nullable: false),
                        FarmOwner_FarmOwnerId = c.Int(),
                    })
                .PrimaryKey(t => t.BroadcastId)
                .ForeignKey("dbo.Contagions", t => t.ContagionId)
                .ForeignKey("dbo.FarmOwners", t => t.FarmOwner_FarmOwnerId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.ContagionId)
                .Index(t => t.UserId)
                .Index(t => t.FarmOwner_FarmOwnerId);
            
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContagionId)
                .ForeignKey("dbo.FarmPlants", t => t.FarmPlantId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.FarmPlantId)
                .Index(t => t.UserId);
            
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
                        URL = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Disease_DiseaseId = c.Int(),
                        FarmOwner_FarmOwnerId = c.Int(),
                        Plant_PlantId = c.Int(),
                        Pest_PestId = c.Int(),
                        Contagion_ContagionId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.Diseases", t => t.Disease_DiseaseId)
                .ForeignKey("dbo.FarmOwners", t => t.FarmOwner_FarmOwnerId)
                .ForeignKey("dbo.Plants", t => t.Plant_PlantId)
                .ForeignKey("dbo.Pests", t => t.Pest_PestId)
                .ForeignKey("dbo.Contagions", t => t.Contagion_ContagionId)
                .Index(t => t.Disease_DiseaseId)
                .Index(t => t.FarmOwner_FarmOwnerId)
                .Index(t => t.Plant_PlantId)
                .Index(t => t.Pest_PestId)
                .Index(t => t.Contagion_ContagionId);
            
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
                "dbo.Geopositions",
                c => new
                    {
                        GeopositionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GeoData = c.String(storeType: "ntext"),
                        Area = c.Single(nullable: false),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        FarmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeopositionId)
                .ForeignKey("dbo.Farms", t => t.FarmId, cascadeDelete: true)
                .Index(t => t.FarmId);
            
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
                        UserId = c.Int(nullable: false),
                        FarmOwnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FarmId)
                .ForeignKey("dbo.FarmOwners", t => t.FarmOwnerId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.FarmOwnerId);
            
            CreateTable(
                "dbo.FarmOwners",
                c => new
                    {
                        FarmOwnerId = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        PassportNumber = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        MobilePhone1 = c.String(nullable: false),
                        MobilePhone2 = c.String(),
                        HomePhone1 = c.String(nullable: false),
                        HomePhone2 = c.String(),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        Region = c.String(),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FarmOwnerId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SoilReadingId)
                .ForeignKey("dbo.Geopositions", t => t.GeopositionId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.GeopositionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Plants",
                c => new
                    {
                        PlantId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                "dbo.Pests",
                c => new
                    {
                        PestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        Feedback = c.String(storeType: "ntext"),
                        MessageText = c.String(storeType: "ntext"),
                        Date = c.DateTime(nullable: false),
                        BroadcastId = c.Int(),
                        FarmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Broadcasts", t => t.BroadcastId)
                .ForeignKey("dbo.Farms", t => t.FarmId, cascadeDelete: true)
                .Index(t => new { t.BroadcastId, t.FarmId }, unique: true, name: "IX_UniqueMessage");
            
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
            DropForeignKey("dbo.Broadcasts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "FarmId", "dbo.Farms");
            DropForeignKey("dbo.Messages", "BroadcastId", "dbo.Broadcasts");
            DropForeignKey("dbo.Contagions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Photos", "Contagion_ContagionId", "dbo.Contagions");
            DropForeignKey("dbo.Photos", "Pest_PestId", "dbo.Pests");
            DropForeignKey("dbo.PestContagions", "Contagion_ContagionId", "dbo.Contagions");
            DropForeignKey("dbo.PestContagions", "Pest_PestId", "dbo.Pests");
            DropForeignKey("dbo.FarmPlants", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Photos", "Plant_PlantId", "dbo.Plants");
            DropForeignKey("dbo.FarmPlants", "GeopositionId", "dbo.Geopositions");
            DropForeignKey("dbo.Geopositions", "FarmId", "dbo.Farms");
            DropForeignKey("dbo.Farms", "UserId", "dbo.Users");
            DropForeignKey("dbo.Farms", "FarmOwnerId", "dbo.FarmOwners");
            DropForeignKey("dbo.FarmOwners", "UserId", "dbo.Users");
            DropForeignKey("dbo.SoilReadings", "UserId", "dbo.Users");
            DropForeignKey("dbo.SoilReadings", "GeopositionId", "dbo.Geopositions");
            DropForeignKey("dbo.Photos", "FarmOwner_FarmOwnerId", "dbo.FarmOwners");
            DropForeignKey("dbo.Broadcasts", "FarmOwner_FarmOwnerId", "dbo.FarmOwners");
            DropForeignKey("dbo.Contagions", "FarmPlantId", "dbo.FarmPlants");
            DropForeignKey("dbo.Photos", "Disease_DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.DiseaseContagions", "Contagion_ContagionId", "dbo.Contagions");
            DropForeignKey("dbo.DiseaseContagions", "Disease_DiseaseId", "dbo.Diseases");
            DropForeignKey("dbo.Broadcasts", "ContagionId", "dbo.Contagions");
            DropIndex("dbo.PestContagions", new[] { "Contagion_ContagionId" });
            DropIndex("dbo.PestContagions", new[] { "Pest_PestId" });
            DropIndex("dbo.DiseaseContagions", new[] { "Contagion_ContagionId" });
            DropIndex("dbo.DiseaseContagions", new[] { "Disease_DiseaseId" });
            DropIndex("dbo.Messages", "IX_UniqueMessage");
            DropIndex("dbo.SoilReadings", new[] { "UserId" });
            DropIndex("dbo.SoilReadings", new[] { "GeopositionId" });
            DropIndex("dbo.FarmOwners", new[] { "UserId" });
            DropIndex("dbo.Farms", new[] { "FarmOwnerId" });
            DropIndex("dbo.Farms", new[] { "UserId" });
            DropIndex("dbo.Geopositions", new[] { "FarmId" });
            DropIndex("dbo.FarmPlants", "IX_UniqueFarmPlant");
            DropIndex("dbo.Photos", new[] { "Contagion_ContagionId" });
            DropIndex("dbo.Photos", new[] { "Pest_PestId" });
            DropIndex("dbo.Photos", new[] { "Plant_PlantId" });
            DropIndex("dbo.Photos", new[] { "FarmOwner_FarmOwnerId" });
            DropIndex("dbo.Photos", new[] { "Disease_DiseaseId" });
            DropIndex("dbo.Contagions", new[] { "UserId" });
            DropIndex("dbo.Contagions", new[] { "FarmPlantId" });
            DropIndex("dbo.Broadcasts", new[] { "FarmOwner_FarmOwnerId" });
            DropIndex("dbo.Broadcasts", new[] { "UserId" });
            DropIndex("dbo.Broadcasts", new[] { "ContagionId" });
            DropTable("dbo.PestContagions");
            DropTable("dbo.DiseaseContagions");
            DropTable("dbo.Messages");
            DropTable("dbo.Pests");
            DropTable("dbo.Plants");
            DropTable("dbo.SoilReadings");
            DropTable("dbo.Users");
            DropTable("dbo.FarmOwners");
            DropTable("dbo.Farms");
            DropTable("dbo.Geopositions");
            DropTable("dbo.FarmPlants");
            DropTable("dbo.Photos");
            DropTable("dbo.Diseases");
            DropTable("dbo.Contagions");
            DropTable("dbo.Broadcasts");
        }
    }
}
