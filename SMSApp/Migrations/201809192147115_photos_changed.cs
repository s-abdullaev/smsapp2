namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photos_changed : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Photos", name: "Contagion_ContagionId", newName: "ContagionId");
            RenameColumn(table: "dbo.Photos", name: "Disease_DiseaseId", newName: "DiseaseId");
            RenameColumn(table: "dbo.Photos", name: "FarmOwner_FarmOwnerId", newName: "FarmOwnerId");
            RenameColumn(table: "dbo.Photos", name: "Plant_PlantId", newName: "PlantId");
            RenameColumn(table: "dbo.Photos", name: "Pest_PestId", newName: "PestId");
            RenameIndex(table: "dbo.Photos", name: "IX_FarmOwner_FarmOwnerId", newName: "IX_FarmOwnerId");
            RenameIndex(table: "dbo.Photos", name: "IX_Plant_PlantId", newName: "IX_PlantId");
            RenameIndex(table: "dbo.Photos", name: "IX_Disease_DiseaseId", newName: "IX_DiseaseId");
            RenameIndex(table: "dbo.Photos", name: "IX_Pest_PestId", newName: "IX_PestId");
            RenameIndex(table: "dbo.Photos", name: "IX_Contagion_ContagionId", newName: "IX_ContagionId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Photos", name: "IX_ContagionId", newName: "IX_Contagion_ContagionId");
            RenameIndex(table: "dbo.Photos", name: "IX_PestId", newName: "IX_Pest_PestId");
            RenameIndex(table: "dbo.Photos", name: "IX_DiseaseId", newName: "IX_Disease_DiseaseId");
            RenameIndex(table: "dbo.Photos", name: "IX_PlantId", newName: "IX_Plant_PlantId");
            RenameIndex(table: "dbo.Photos", name: "IX_FarmOwnerId", newName: "IX_FarmOwner_FarmOwnerId");
            RenameColumn(table: "dbo.Photos", name: "PestId", newName: "Pest_PestId");
            RenameColumn(table: "dbo.Photos", name: "PlantId", newName: "Plant_PlantId");
            RenameColumn(table: "dbo.Photos", name: "FarmOwnerId", newName: "FarmOwner_FarmOwnerId");
            RenameColumn(table: "dbo.Photos", name: "DiseaseId", newName: "Disease_DiseaseId");
            RenameColumn(table: "dbo.Photos", name: "ContagionId", newName: "Contagion_ContagionId");
        }
    }
}
