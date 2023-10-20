using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebStore.Model;

namespace WebStore.DAL;
public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<StationaryStore> StationaryStores { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Order>()
        .HasMany(e => e.Products)
        .WithMany(e => e.Orders)
        .UsingEntity<OrderProduct>(
            j => j.Property(e => e.Quantity)
        );

        modelBuilder.Entity<Supplier>()
            .HasMany(e => e.Products)
            .WithOne(e => e.Supplier)
            .OnDelete(DeleteBehavior.Restrict);

        // modelBuilder.Entity<Customer>().HasMany(t => t.ShippingAddresses)
        //     .WithOne(g => g.Address)
        //     .HasForeignKey(g => g.AddressId);

        // modelBuilder.Entity<Customer>().HasMany(t => t.BillingAddresses)
        //     .WithOne(g => g.Address)
        //     .HasForeignKey(g => g.AddressId).OnDelete(DeleteBehavior.Restrict);
    

        base.OnModelCreating(modelBuilder);
}
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlServer("server=localhost;database=APP2;trusted_connection=true;");
}

}
