namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generateChangedToBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FarmOwners", "Gender", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FarmOwners", "Gender");
        }
    }
}
