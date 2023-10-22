using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebStore.Model;

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

    //     // Configure the relationships
    // modelBuilder.Entity<Customer>()
    //     .HasOne(c => c.BillingAddress)
    //     .WithMany()
    //     .HasForeignKey(c => c.BillingAddressId);

    // modelBuilder.Entity<Customer>()
    //     .HasOne(c => c.ShippingAddress)
    //     .WithMany()
    //     .HasForeignKey(c => c.ShippingAddressId);

    // Add other configurations for your entities here

    // Call the base OnModelCreating method to apply any additional configurations
    base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        optionsBuilder.UseSqlServer("Server=DESKTOP-13RDMPJ;Database=WebStoreDb;Trusted_Connection=True;");
    }
}
