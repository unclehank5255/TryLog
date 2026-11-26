namespace TryLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailChangeAndUserSettings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailChangeRequests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OldEmail = c.String(nullable: false, maxLength: 254),
                        NewEmail = c.String(nullable: false, maxLength: 254),
                        TokenHash = c.String(nullable: false, maxLength: 64),
                        TokenExpiresAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Status = c.Int(nullable: false),
                        RevertTokenHash = c.String(maxLength: 64),
                        RevertExpiresAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CompletedAt = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TokenHash)
                .Index(t => t.RevertTokenHash);
            
            AddColumn("dbo.Users", "PendingTimeZone", c => c.String(maxLength: 64));
            AddColumn("dbo.Users", "TimeZoneEffectiveDate", c => c.DateTime(storeType: "date"));
            AddColumn("dbo.Users", "AvatarColor", c => c.Byte(nullable: false));
            AlterColumn("dbo.CheckIns", "Status", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmailChangeRequests", "UserId", "dbo.Users");
            DropIndex("dbo.EmailChangeRequests", new[] { "RevertTokenHash" });
            DropIndex("dbo.EmailChangeRequests", new[] { "TokenHash" });
            DropIndex("dbo.EmailChangeRequests", new[] { "UserId" });
            AlterColumn("dbo.CheckIns", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "AvatarColor");
            DropColumn("dbo.Users", "TimeZoneEffectiveDate");
            DropColumn("dbo.Users", "PendingTimeZone");
            DropTable("dbo.EmailChangeRequests");
        }
    }
}
