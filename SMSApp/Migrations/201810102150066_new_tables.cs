namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_tables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FarmPlants", "GeopositionId", "dbo.Geopositions");
            DropForeignKey("dbo.FarmPlants", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.Contagions", "FarmPlantId", "dbo.FarmPlants");
            DropForeignKey("dbo.Geopositions", "FarmId", "dbo.Farms");
            DropIndex("dbo.Contagions", new[] { "FarmPlantId" });
            DropIndex("dbo.Geopositions", new[] { "FarmId" });
            DropIndex("dbo.FarmPlants", "IX_UniqueFarmPlant");
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        SeasonId = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        SeasonTime = c.Int(nullable: false),
                        GrowthStatus = c.Int(nullable: false),
                        ExpectedYield = c.Double(nullable: false),
                        InitialInvestment = c.Double(nullable: false),
                        AdditionalNotes = c.String(storeType: "ntext"),
                        GeopositionId = c.Int(),
                    })
                .PrimaryKey(t => t.SeasonId)
                .ForeignKey("dbo.Geopositions", t => t.GeopositionId)
                .Index(t => new { t.GeopositionId, t.Year, t.SeasonTime }, unique: true, name: "IX_UniqueFarmPlant");
            
            CreateTable(
                "dbo.SeasonPlants",
                c => new
                    {
                        SeasonPlantId = c.Int(nullable: false, identity: true),
                        SeasonId = c.Int(nullable: false),
                        PlantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeasonPlantId)
                .ForeignKey("dbo.Seasons", t => t.SeasonId, cascadeDelete: true)
                .Index(t => t.SeasonId);
            
            AddColumn("dbo.Contagions", "FarmPlant_SeasonId", c => c.Int());
            AlterColumn("dbo.Geopositions", "FarmId", c => c.Int());
            CreateIndex("dbo.Contagions", "FarmPlant_SeasonId");
            CreateIndex("dbo.Geopositions", "FarmId");
            AddForeignKey("dbo.Contagions", "FarmPlant_SeasonId", "dbo.Seasons", "SeasonId");
            AddForeignKey("dbo.Geopositions", "FarmId", "dbo.Farms", "FarmId");
            DropTable("dbo.FarmPlants");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.FarmPlantId);
            
            DropForeignKey("dbo.Geopositions", "FarmId", "dbo.Farms");
            DropForeignKey("dbo.Contagions", "FarmPlant_SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.SeasonPlants", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.Seasons", "GeopositionId", "dbo.Geopositions");
            DropIndex("dbo.SeasonPlants", new[] { "SeasonId" });
            DropIndex("dbo.Seasons", "IX_UniqueFarmPlant");
            DropIndex("dbo.Geopositions", new[] { "FarmId" });
            DropIndex("dbo.Contagions", new[] { "FarmPlant_SeasonId" });
            AlterColumn("dbo.Geopositions", "FarmId", c => c.Int(nullable: false));
            DropColumn("dbo.Contagions", "FarmPlant_SeasonId");
            DropTable("dbo.SeasonPlants");
            DropTable("dbo.Seasons");
            CreateIndex("dbo.FarmPlants", new[] { "GeopositionId", "PlantId", "Year", "Season" }, unique: true, name: "IX_UniqueFarmPlant");
            CreateIndex("dbo.Geopositions", "FarmId");
            CreateIndex("dbo.Contagions", "FarmPlantId");
            AddForeignKey("dbo.Geopositions", "FarmId", "dbo.Farms", "FarmId", cascadeDelete: true);
            AddForeignKey("dbo.Contagions", "FarmPlantId", "dbo.FarmPlants", "FarmPlantId");
            AddForeignKey("dbo.FarmPlants", "PlantId", "dbo.Plants", "PlantId");
            AddForeignKey("dbo.FarmPlants", "GeopositionId", "dbo.Geopositions", "GeopositionId");
        }
    }
}
