namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minor_changes : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SeasonPlants", "PlantId");
            AddForeignKey("dbo.SeasonPlants", "PlantId", "dbo.Plants", "PlantId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SeasonPlants", "PlantId", "dbo.Plants");
            DropIndex("dbo.SeasonPlants", new[] { "PlantId" });
        }
    }
}
