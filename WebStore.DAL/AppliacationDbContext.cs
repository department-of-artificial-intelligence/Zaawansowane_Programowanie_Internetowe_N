using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using WebStore.Model;

namespace WebStore.DAL;

public class ApplicationDbContext : DbContext
{
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

    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    private readonly static string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=WebStoreAppDb;Trusted_Connection=True;MultipleActiveResultSets=true";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer(_connectionString);
    }
}