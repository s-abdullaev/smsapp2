namespace SMSApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagesSentToFarms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "FarmOwnerId", "dbo.FarmOwners");
            DropIndex("dbo.Messages", "IX_UniqueMessage");
            AddColumn("dbo.Messages", "FarmId", c => c.Int(nullable: false));
            CreateIndex("dbo.Messages", new[] { "BroadcastId", "FarmId" }, unique: true, name: "IX_UniqueMessage");
            AddForeignKey("dbo.Messages", "FarmId", "dbo.Farms", "FarmId", cascadeDelete: true);
            DropColumn("dbo.Messages", "FarmOwnerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "FarmOwnerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Messages", "FarmId", "dbo.Farms");
            DropIndex("dbo.Messages", "IX_UniqueMessage");
            DropColumn("dbo.Messages", "FarmId");
            CreateIndex("dbo.Messages", new[] { "BroadcastId", "FarmOwnerId" }, unique: true, name: "IX_UniqueMessage");
            AddForeignKey("dbo.Messages", "FarmOwnerId", "dbo.FarmOwners", "FarmOwnerId", cascadeDelete: true);
        }
    }
}
