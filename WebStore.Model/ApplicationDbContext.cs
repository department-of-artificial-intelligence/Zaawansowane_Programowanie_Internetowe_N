using Microsoft.EntityFrameworkCore;

namespace WebStore.Model;

public class ApplicationDbContext : DbContext
{
    public static ApplicationDbContext Create()
    {
        return new ApplicationDbContext();
    }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    private ApplicationDbContext()
    {
        throw new NotImplementedException();
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<StationaryStore> StationaryStores { get; set; }
    public DbSet<StationaryStoreEmployee> StationaryStoreEmployees { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }
}