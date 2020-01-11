namespace ProductSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "Stock_StockID", "dbo.Stocks");
            DropIndex("dbo.Items", new[] { "Stock_StockID" });
            DropColumn("dbo.Items", "Stock_StockID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Stock_StockID", c => c.Int());
            CreateIndex("dbo.Items", "Stock_StockID");
            AddForeignKey("dbo.Items", "Stock_StockID", "dbo.Stocks", "StockID");
        }
    }
}
