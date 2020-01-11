namespace ProductSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablesddd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stocks", "ProductID", c => c.Int(nullable: false));
            DropColumn("dbo.Stocks", "ProductName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stocks", "ProductName", c => c.String());
            DropColumn("dbo.Stocks", "ProductID");
        }
    }
}
