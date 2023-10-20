using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebStore.Model.Entities;

namespace WebStore.DAL.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly static string _connectionString = "Data Source=localhost; Initial Catalog = WebStore; User ID=sa; Password=123; TrustServerCertificate=True;";
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        public DbSet<Address> Addresses {get;set;}
        public DbSet<Category> Categories {get;set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders {get;set;}
        public DbSet<Product> Products {get;set;}
        public DbSet<ProductStock> ProductStocks {get;set;}
        public DbSet<StationaryStore> StationaryStores {get;set;}
        public DbSet<StationaryStoreEmployee> StationaryStoreEmployees {get;set;}
        public DbSet<Supplier> suppliers {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<OrderProduct> OrderProduct {get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}