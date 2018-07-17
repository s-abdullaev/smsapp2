namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesMessageTextAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageText", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageText");
        }
    }
}
