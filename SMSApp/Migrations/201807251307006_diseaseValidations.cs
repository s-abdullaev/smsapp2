namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diseaseValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diseases", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Diseases", "Name", c => c.String());
        }
    }
}
