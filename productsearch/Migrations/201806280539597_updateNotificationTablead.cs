namespace ProductSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNotificationTablead : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notifications", "ProductID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "ProductID", c => c.Int(nullable: false));
        }
    }
}
