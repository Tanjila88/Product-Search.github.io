namespace ProductSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNotificationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        NotificationID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        NotifyText = c.String(),
                        NotifyDate = c.String(),
                    })
                .PrimaryKey(t => t.NotificationID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notifications");
        }
    }
}
