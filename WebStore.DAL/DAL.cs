using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public DbSet<StationaryStoreEmployee> StationaryStoreEmployees { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Customer - Order
        builder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        // Supplier - Product
        builder.Entity<Supplier>()
            .HasMany(s => s.Products)
            .WithOne(p => p.Supplier)
            .HasForeignKey(p => p.SupplierId);

        // Product - ProductStock (zakładając, że to one-to-one)
        builder.Entity<Product>()
            .HasOne(p => p.ProductStock)
            .WithOne(ps => ps.Product)
            .HasForeignKey<ProductStock>(ps => ps.ProductId);

        // Category - Product
        builder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        // StationaryStore - StationaryStoreEmployee
        builder.Entity<StationaryStore>()
            .HasMany(ss => ss.Employees)
            .WithOne(e => e.Store)
            .HasForeignKey(e => e.StoreId);

                // Order - Product przy użyciu encji asocjacyjnej OrderProduct
        builder.Entity<OrderProduct>()
            .HasKey(op => new { op.OrderId, op.ProductId });

        builder.Entity<OrderProduct>()
            .HasOne(op => op.Order)
            .WithMany(o => o.OrderProducts)
            .HasForeignKey(op => op.OrderId);

        builder.Entity<OrderProduct>()
            .HasOne(op => op.Product)
            .WithMany(p => p.OrderProducts)
            .HasForeignKey(op => op.ProductId);


        // Dziedziczenie TPH dla User, Customer, Supplier, StationaryStoreEmployee
        builder.Entity<User>()
            .ToTable("Users")
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Customer>("Customer")
            .HasValue<Supplier>("Supplier")
            .HasValue<StationaryStoreEmployee>("StationaryStoreEmployee");

        builder.Entity<User>()
            .ToTable("Users")
            .HasDiscriminator<string>("UserType")
            .HasValue<User>("User")
            .HasValue<Customer>("Customer")
            .HasValue<Supplier>("Supplier")
            .HasValue<StationaryStoreEmployee>("StationaryStoreEmployee");
    }
}
