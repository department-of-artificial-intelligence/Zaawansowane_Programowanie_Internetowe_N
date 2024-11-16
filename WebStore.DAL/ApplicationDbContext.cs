
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStore.Model;

namespace WebStore.DAL
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StationaryStore> StationaryStores { get; set; }
        public DbSet<StationaryStoreEmployee> StationaryStoreEmployees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TPH for User hierarchy
            modelBuilder.Entity<User>()
                .ToTable("Users")
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Customer>("Customer")
                .HasValue<Supplier>("Supplier")
                .HasValue<StationaryStoreEmployee>("StationaryStoreEmployee");

            // One-to-Many: Customer -> Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            // One-to-Many: Product -> ProductStock
            modelBuilder.Entity<ProductStock>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductStocks)
                .HasForeignKey(ps => ps.ProductId);

            // One-to-Many: Category -> Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Many-to-Many: Order <-> Product through OrderProduct
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            // One-to-Many: StationaryStore -> Address
            modelBuilder.Entity<StationaryStore>()
                .HasMany(s => s.AddressList)
                .WithOne(a => a.StationaryStore);

            // One-to-Many: StationaryStore -> StationaryStoreEmployee
            modelBuilder.Entity<StationaryStoreEmployee>()
                .HasOne(e => e.StationaryStore)
                .WithMany(s => s.Employees);

            // One-to-Many: Supplier -> Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products);

            modelBuilder.Entity<User>()
    .ToTable("Users")
    .HasDiscriminator<string>("UserType")
    .HasValue<User>("User")
    .HasValue<Customer>("Customer")
    .HasValue<Supplier>("Supplier")
    .HasValue<StationaryStoreEmployee>("StationaryStoreEmployee");
        }
    }
}