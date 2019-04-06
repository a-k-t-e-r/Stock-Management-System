namespace Stock_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ver2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockOuts", "ProductStatus", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockOuts", "ProductStatus");
        }
    }
}
