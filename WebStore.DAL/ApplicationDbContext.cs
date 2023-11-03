using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebStore.Model;

namespace WebStore.DAL;
public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
{

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<StationaryStore> StationaryStores { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

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

        modelBuilder.Entity<User>()
            .HasDiscriminator<int>("UserType")
            .HasValue<Customer>(1)
            .HasValue<Supplier>(2)
            .HasValue<StationaryStoreEmployee>(3);

        base.OnModelCreating(modelBuilder);
}

//wylaczone na poczet testow
// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// {
//     optionsBuilder.UseSqlServer("server=localhost;database=APP2;trusted_connection=true;");
// }

}
