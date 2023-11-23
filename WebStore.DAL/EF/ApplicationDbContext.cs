using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Model;

namespace WebStore.DAL.EF
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Order> Orders { get; set; } = default!;
        public DbSet<OrderProduct> OrderProducts { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<ProductStock> ProductStocks { get; set; } = default!;
        public DbSet<StationaryStore> StationaryStores { get; set; } = default!;
        public DbSet<StationaryStoreEmployee> StationaryStoreEmployees { get; set; } = default!;
        public DbSet<Supplier> Suppliers { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Invoice> Invoice { get; set; } = default!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .ToTable("AspNetUsers")
                .HasDiscriminator<int>("UserType")
                .HasValue<User>(0)
                .HasValue<Customer>(1)
                .HasValue<Supplier>(2)
                .HasValue<StationaryStoreEmployee>(3);

            modelBuilder.Entity<OrderProduct>()
                .ToTable("OrderProduct")
                .HasKey(x => new { x.OrderId, x.ProductId });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.StationaryStore)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.StationaryStoreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.Entity<OrderProduct>()
            //     .HasOne(x => x.Order)
            //     .WithMany(y => y.OrderProducts)
            //     .HasForeignKey(x => x.OrderId)
            //     .OnDelete(DeleteBehavior.NoAction);

            // modelBuilder.Entity<OrderProduct>()
            //     .HasOne(x => x.Product)
            //     .WithMany(y => y.OrderProducts)
            //     .HasForeignKey(x => x.ProductId)
            //     .OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<Order>()
            //     .HasOne(o => o.Customer)
            //     .WithMany(c => c.Orders)
            //     .HasForeignKey(o => o.CustomerId)
            //     .OnDelete(DeleteBehavior.NoAction);
            // modelBuilder.Entity<Order>()
            //     .HasOne(o => o.StationaryStore)
            //     .WithMany(s => s.Orders)
            //     .HasForeignKey(o => o.StationaryStoreId)
            //     .OnDelete(DeleteBehavior.NoAction);
        }
    }
}