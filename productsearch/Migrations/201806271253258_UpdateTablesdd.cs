namespace ProductSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablesdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Stocks", "PurchaseID", "dbo.Purchases");
            DropIndex("dbo.Stocks", new[] { "PurchaseID" });
            AddColumn("dbo.Stocks", "ProductName", c => c.String());
            DropColumn("dbo.Stocks", "PurchaseID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "PurchaseID", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "ProductName");
            CreateIndex("dbo.Stocks", "PurchaseID");
            AddForeignKey("dbo.Stocks", "PurchaseID", "dbo.Purchases", "PurchaseID", cascadeDelete: true);
        }
    }
}
