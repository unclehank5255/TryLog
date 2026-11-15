namespace TryLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attempts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoalId = c.Int(nullable: false),
                        AttemptNo = c.Int(nullable: false),
                        Content = c.String(nullable: false, maxLength: 30),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        EndDate = c.DateTime(nullable: false, storeType: "date"),
                        Plus = c.String(maxLength: 200),
                        Minus = c.String(maxLength: 200),
                        Result = c.Int(),
                        EvaluatedAt = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goals", t => t.GoalId, cascadeDelete: true)
                .Index(t => new { t.GoalId, t.AttemptNo }, unique: true, name: "IX_Goal_AttemptNo");
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        Why = c.String(maxLength: 100),
                        IsPinned = c.Boolean(nullable: false),
                        StartDate = c.DateTime(nullable: false, storeType: "date"),
                        ReminderTime = c.Time(precision: 7),
                        ArchivedAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CheckIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoalId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Status = c.Int(nullable: false),
                        Note = c.String(maxLength: 200),
                        PhotoPath = c.String(maxLength: 260),
                        UpdatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goals", t => t.GoalId, cascadeDelete: true)
                .Index(t => new { t.GoalId, t.Date }, unique: true, name: "IX_Goal_Date");
            
            CreateTable(
                "dbo.GoalSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GoalId = c.Int(nullable: false),
                        EffectiveDate = c.DateTime(nullable: false, storeType: "date"),
                        FrequencyType = c.Int(nullable: false),
                        DaysPerWeek = c.Int(),
                        Weekdays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Goals", t => t.GoalId, cascadeDelete: true)
                .Index(t => new { t.GoalId, t.EffectiveDate }, unique: true, name: "IX_Goal_EffectiveDate");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 254),
                        PasswordHash = c.String(maxLength: 128),
                        TimeZone = c.String(nullable: false, maxLength: 64),
                        IsEmailVerified = c.Boolean(nullable: false),
                        EmailVerificationTokenHash = c.String(maxLength: 64),
                        EmailVerificationTokenExpiresAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        PasswordResetTokenHash = c.String(maxLength: 64),
                        PasswordResetTokenExpiresAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        Role = c.Int(nullable: false),
                        BannedAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        MarkedAt = c.DateTime(precision: 7, storeType: "datetime2"),
                        SecurityStamp = c.String(nullable: false, maxLength: 64),
                        SortMode = c.Int(nullable: false),
                        Theme = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Provider = c.String(nullable: false, maxLength: 32),
                        ProviderKey = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => new { t.Provider, t.ProviderKey }, unique: true, name: "IX_Provider_Key");
            
            CreateTable(
                "dbo.DailyMoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Mood = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => new { t.UserId, t.Date }, unique: true, name: "IX_User_Date");
            
            CreateTable(
                "dbo.PushSubscriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Endpoint = c.String(nullable: false, maxLength: 500),
                        P256dh = c.String(nullable: false, maxLength: 100),
                        Auth = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.Endpoint, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PushSubscriptions", "UserId", "dbo.Users");
            DropForeignKey("dbo.DailyMoods", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Goals", "UserId", "dbo.Users");
            DropForeignKey("dbo.GoalSchedules", "GoalId", "dbo.Goals");
            DropForeignKey("dbo.CheckIns", "GoalId", "dbo.Goals");
            DropForeignKey("dbo.Attempts", "GoalId", "dbo.Goals");
            DropIndex("dbo.PushSubscriptions", new[] { "Endpoint" });
            DropIndex("dbo.PushSubscriptions", new[] { "UserId" });
            DropIndex("dbo.DailyMoods", "IX_User_Date");
            DropIndex("dbo.UserLogins", "IX_Provider_Key");
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.GoalSchedules", "IX_Goal_EffectiveDate");
            DropIndex("dbo.CheckIns", "IX_Goal_Date");
            DropIndex("dbo.Goals", new[] { "UserId" });
            DropIndex("dbo.Attempts", "IX_Goal_AttemptNo");
            DropTable("dbo.PushSubscriptions");
            DropTable("dbo.DailyMoods");
            DropTable("dbo.UserLogins");
            DropTable("dbo.Users");
            DropTable("dbo.GoalSchedules");
            DropTable("dbo.CheckIns");
            DropTable("dbo.Goals");
            DropTable("dbo.Attempts");
        }
    }
}
