namespace TNS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInTimeUnitsDataTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SubscriptionType", "SecondsTotal", c => c.Int(nullable: false));
            AddColumn("dbo.SubscriptionType", "Name", c => c.String());
            AddColumn("dbo.User", "SecondsLeft", c => c.Int(nullable: false));
            DropColumn("dbo.SubscriptionType", "MinutesTotal");
            DropColumn("dbo.User", "MinutesLeft");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "MinutesLeft", c => c.DateTime(nullable: false));
            AddColumn("dbo.SubscriptionType", "MinutesTotal", c => c.DateTime(nullable: false));
            DropColumn("dbo.User", "SecondsLeft");
            DropColumn("dbo.SubscriptionType", "Name");
            DropColumn("dbo.SubscriptionType", "SecondsTotal");
        }
    }
}
