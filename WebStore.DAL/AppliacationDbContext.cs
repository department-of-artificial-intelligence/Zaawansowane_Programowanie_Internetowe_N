using Microsoft.EntityFrameworkCore;
using WebStore.Model;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders  { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<StationaryStore> StationaryStores { get; set; }
    public DbSet<StationaryStoreEmployee> StationaryStoreEmployees { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    
    }   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        

    }
}
