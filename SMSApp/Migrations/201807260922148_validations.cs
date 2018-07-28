namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Broadcasts", "MessageText", c => c.String(nullable: false, storeType: "ntext"));
            AlterColumn("dbo.Photos", "URL", c => c.String(nullable: false));
            AlterColumn("dbo.Geopositions", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Farms", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Farms", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.FarmOwners", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.FarmOwners", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.FarmOwners", "PassportNumber", c => c.String(nullable: false));
            AlterColumn("dbo.FarmOwners", "MobilePhone1", c => c.String(nullable: false));
            AlterColumn("dbo.FarmOwners", "HomePhone1", c => c.String(nullable: false));
            AlterColumn("dbo.FarmOwners", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Plants", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Pests", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Messages", "MessageText", c => c.String(nullable: false, storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageText", c => c.String(storeType: "ntext"));
            AlterColumn("dbo.Pests", "Name", c => c.String());
            AlterColumn("dbo.Plants", "Name", c => c.String());
            AlterColumn("dbo.FarmOwners", "Email", c => c.String());
            AlterColumn("dbo.FarmOwners", "HomePhone1", c => c.String());
            AlterColumn("dbo.FarmOwners", "MobilePhone1", c => c.String());
            AlterColumn("dbo.FarmOwners", "PassportNumber", c => c.String());
            AlterColumn("dbo.FarmOwners", "FirstName", c => c.String());
            AlterColumn("dbo.FarmOwners", "LastName", c => c.String());
            AlterColumn("dbo.Farms", "Address", c => c.String());
            AlterColumn("dbo.Farms", "Name", c => c.String());
            AlterColumn("dbo.Geopositions", "Name", c => c.String());
            AlterColumn("dbo.Photos", "URL", c => c.String());
            AlterColumn("dbo.Broadcasts", "MessageText", c => c.String(storeType: "ntext"));
        }
    }
}
