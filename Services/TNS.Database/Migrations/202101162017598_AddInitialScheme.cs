namespace TNS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialScheme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BaseStationLoad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseStationId = c.Int(nullable: false),
                        TimeSaved = c.DateTime(nullable: false),
                        CurrentLoad = c.Int(nullable: false),
                        LoadMax = c.Int(nullable: false),
                        LoadAverage = c.Int(nullable: false),
                        InQueueMax = c.Int(nullable: false),
                        InQueueAverage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseStation", t => t.BaseStationId, cascadeDelete: true)
                .Index(t => t.BaseStationId);
            
            CreateTable(
                "dbo.BaseStation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Capacity = c.Int(nullable: false),
                        BaseStationStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Constants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserCallChance = c.Int(nullable: false),
                        UserTravelChance = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriptionType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinutesTotal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BaseStationId = c.Int(nullable: false),
                        SubscriptionTypeId = c.Int(nullable: false),
                        UserStatusId = c.Int(nullable: false),
                        MinutesLeft = c.DateTime(nullable: false),
                        FullName = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BaseStation", t => t.BaseStationId, cascadeDelete: true)
                .ForeignKey("dbo.SubscriptionType", t => t.SubscriptionTypeId, cascadeDelete: true)
                .Index(t => t.BaseStationId)
                .Index(t => t.SubscriptionTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "SubscriptionTypeId", "dbo.SubscriptionType");
            DropForeignKey("dbo.User", "BaseStationId", "dbo.BaseStation");
            DropForeignKey("dbo.BaseStationLoad", "BaseStationId", "dbo.BaseStation");
            DropIndex("dbo.User", new[] { "SubscriptionTypeId" });
            DropIndex("dbo.User", new[] { "BaseStationId" });
            DropIndex("dbo.BaseStationLoad", new[] { "BaseStationId" });
            DropTable("dbo.User");
            DropTable("dbo.SubscriptionType");
            DropTable("dbo.Constants");
            DropTable("dbo.BaseStation");
            DropTable("dbo.BaseStationLoad");
        }
    }
}
