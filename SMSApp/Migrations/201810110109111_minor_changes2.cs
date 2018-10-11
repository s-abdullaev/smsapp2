namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changes2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SeasonPlants", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.SeasonPlants", "PlantId", "dbo.Plants");
            DropIndex("dbo.SeasonPlants", new[] { "SeasonId" });
            DropIndex("dbo.SeasonPlants", new[] { "PlantId" });
            AlterColumn("dbo.SeasonPlants", "SeasonId", c => c.Int());
            AlterColumn("dbo.SeasonPlants", "PlantId", c => c.Int());
            CreateIndex("dbo.SeasonPlants", "SeasonId");
            CreateIndex("dbo.SeasonPlants", "PlantId");
            AddForeignKey("dbo.SeasonPlants", "SeasonId", "dbo.Seasons", "SeasonId");
            AddForeignKey("dbo.SeasonPlants", "PlantId", "dbo.Plants", "PlantId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeasonPlants", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.SeasonPlants", "SeasonId", "dbo.Seasons");
            DropIndex("dbo.SeasonPlants", new[] { "PlantId" });
            DropIndex("dbo.SeasonPlants", new[] { "SeasonId" });
            AlterColumn("dbo.SeasonPlants", "PlantId", c => c.Int(nullable: false));
            AlterColumn("dbo.SeasonPlants", "SeasonId", c => c.Int(nullable: false));
            CreateIndex("dbo.SeasonPlants", "PlantId");
            CreateIndex("dbo.SeasonPlants", "SeasonId");
            AddForeignKey("dbo.SeasonPlants", "PlantId", "dbo.Plants", "PlantId", cascadeDelete: true);
            AddForeignKey("dbo.SeasonPlants", "SeasonId", "dbo.Seasons", "SeasonId", cascadeDelete: true);
        }
    }
}
