namespace TNS.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCallDelayToConstantsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Constants", "CallDelay", c => c.Int(nullable: false));
            AlterColumn("dbo.User", "Number", c => c.String(maxLength: 200));
            CreateIndex("dbo.User", "Number", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.User", new[] { "Number" });
            AlterColumn("dbo.User", "Number", c => c.String());
            DropColumn("dbo.Constants", "CallDelay");
        }
    }
}
