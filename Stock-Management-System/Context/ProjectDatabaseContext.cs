using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Stock_Management_System.Models;

namespace Stock_Management_System.Context
{
    public class ProjectDatabaseContext : DbContext
    {
        //public ProjectDatabaseContext()
        //    : base("ProjectDatabaseContext")
        //{
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<StockIn> StockIns { get; set; }
        public DbSet<StockOut> StockOuts { get; set; }
        public DbSet<SearchAndViewItemsSummary> SearchAndViewItemsSummaries { get; set; }
        public DbSet<ViewSalesBetweenTwoDates> ViewSalesBetweenTwoDateses { get; set; }
    }
}