namespace Supermarket.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Supermarket.Models;
    using MySQLGetData.Model;
    using Telerik.OpenAccess;


    public class StoreContext : DbContext
    {
        public StoreContext()
            : base("SupermarketDb")
        {

        }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Product> Products { get; set; }

    }
}
