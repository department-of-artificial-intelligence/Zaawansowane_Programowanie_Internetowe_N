using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;  
using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Threading.Tasks;
using WebStore.Model;

namespace WebStore.DAL.EF  
{  
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(){} 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        private readonly static string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=WebStoreAppDb;Trusted_Connection=True;MultipleActiveResultSets=true";
        public DbSet<Address> Address { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<StationaryStore> StationaryStores { get; set; }
        public DbSet<StationaryStoreEmployee> StationaryStoreEmployees { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            //base.OnConfiguring(optionsBuilder);
    //        optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
              base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Order>().HasMany(a => a.products).WithMany(a => a.Orders);
          //  modelBuilder.Entity<Order>().HasOne(a => a.Employee).WithMany(a => a.Orders).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Order>().HasOne(a => a.Client).WithMany(a => a.Orders).OnDelete(DeleteBehavior.NoAction);
        }


    }  
} 