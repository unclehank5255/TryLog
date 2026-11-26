namespace TryLog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNameLengthAndDeviceInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PushSubscriptions", "DeviceName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.PushSubscriptions", "CreatedAt", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.PushSubscriptions", "CreatedAt");
            DropColumn("dbo.PushSubscriptions", "DeviceName");
        }
    }
}
