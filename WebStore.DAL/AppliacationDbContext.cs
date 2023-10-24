using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebStore.Model;
using Microsoft.Extensions.Configuration;

namespace WebStore.DAL;
public class ApplicationDbContext : DbContext
{
    public DbSet<Address> Addresses {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<Invoice> Invoices {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<OrderProduct> OrderProducts {get; set;}
    public DbSet<Product> Products {get; set;}
    public DbSet<ProductStock> ProductStocks {get; set;}
    public DbSet<StationaryStore> StationaryStores {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<Order>()
        .HasMany(e => e.Products)
        .WithMany(e => e.Orders)
        .UsingEntity<OrderProduct>(
           j => j.Property(e => e.Quantity)
        );

         modelBuilder.Entity<User>()
            .HasDiscriminator<int>("UserType")
            .HasValue<Customer>(1)
            .HasValue<Supplier>(2)
            .HasValue<StationaryStoreEmployee>(3);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        // optionsBuilder.UseSqlServer("Server=DESKTOP-13RDMPJ;Database=WebStoreDb;Trusted_Connection=True;");
        optionsBuilder.UseSqlServer("Server=DESKTOP-PMQSLJ5\\SQLEXPRESS; Database=WebStoreDb; Trusted_Connection=True;");   
    
    }
}
