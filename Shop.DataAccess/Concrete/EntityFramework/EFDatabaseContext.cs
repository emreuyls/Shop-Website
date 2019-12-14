using Microsoft.EntityFrameworkCore;
using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.DataAccess.Concrete.EntityFramework
{
   public class EFDatabaseContext:DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> options):base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Shippers> Shippers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductInformation> ProductInformations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductCategory>().HasKey(pk => new { pk.ProductsID, pk.CategoryID, pk.BrandID });        
        }
    }
}
