namespace ProductSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        StockID = c.Int(nullable: false, identity: true),
                        PurchaseID = c.Int(nullable: false),
                        StockQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.StockID)
                .ForeignKey("dbo.Purchases", t => t.PurchaseID, cascadeDelete: true)
                .Index(t => t.PurchaseID);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ItemPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsAvailable = c.Boolean(nullable: false),
                        Stock_StockID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Stocks", t => t.Stock_StockID)
                .Index(t => t.ProductID)
                .Index(t => t.Stock_StockID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.SalesOrders",
                c => new
                    {
                        SalesOrderID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        OrderQnty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalesDate = c.String(),
                    })
                .PrimaryKey(t => t.SalesOrderID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.ItemID);
            
            AddColumn("dbo.Purchases", "SupplierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Purchases", "SupplierID");
            AddForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers", "SupplierID", cascadeDelete: true);
            DropColumn("dbo.Purchases", "SupplierName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "SupplierName", c => c.String());
            DropForeignKey("dbo.SalesOrders", "ItemID", "dbo.Items");
            DropForeignKey("dbo.Purchases", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.Stocks", "PurchaseID", "dbo.Purchases");
            DropForeignKey("dbo.Items", "Stock_StockID", "dbo.Stocks");
            DropForeignKey("dbo.Items", "ProductID", "dbo.Products");
            DropIndex("dbo.SalesOrders", new[] { "ItemID" });
            DropIndex("dbo.Items", new[] { "Stock_StockID" });
            DropIndex("dbo.Items", new[] { "ProductID" });
            DropIndex("dbo.Stocks", new[] { "PurchaseID" });
            DropIndex("dbo.Purchases", new[] { "SupplierID" });
            DropColumn("dbo.Purchases", "SupplierID");
            DropTable("dbo.SalesOrders");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Items");
            DropTable("dbo.Stocks");
        }
    }
}
