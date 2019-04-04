namespace Stock_Management_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ver1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        RecordLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.SearchAndViewItemsSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.StockIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        RecorderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockInQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.CompanyId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.StockOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                        RecorderLevel = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvailableQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockOutQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: false)
                .ForeignKey("dbo.Items", t => t.ItemId, cascadeDelete: false)
                .Index(t => t.CompanyId)
                .Index(t => t.ItemId);
            
            CreateTable(
                "dbo.ViewSalesBetweenTwoDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockOuts", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockOuts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.StockIns", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockIns", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.SearchAndViewItemsSummaries", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.SearchAndViewItemsSummaries", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Items", "CategoryId", "dbo.Categories");
            DropIndex("dbo.StockOuts", new[] { "ItemId" });
            DropIndex("dbo.StockOuts", new[] { "CompanyId" });
            DropIndex("dbo.StockIns", new[] { "ItemId" });
            DropIndex("dbo.StockIns", new[] { "CompanyId" });
            DropIndex("dbo.SearchAndViewItemsSummaries", new[] { "CompanyId" });
            DropIndex("dbo.SearchAndViewItemsSummaries", new[] { "CategoryId" });
            DropIndex("dbo.Items", new[] { "CompanyId" });
            DropIndex("dbo.Items", new[] { "CategoryId" });
            DropTable("dbo.ViewSalesBetweenTwoDates");
            DropTable("dbo.StockOuts");
            DropTable("dbo.StockIns");
            DropTable("dbo.SearchAndViewItemsSummaries");
            DropTable("dbo.Items");
            DropTable("dbo.Companies");
            DropTable("dbo.Categories");
        }
    }
}
