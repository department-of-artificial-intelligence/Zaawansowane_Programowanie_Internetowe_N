using Microsoft.EntityFrameworkCore;
using WebStore.Model;

namespace WebStore.DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Customer>? Customers { get; set; }
    public DbSet<Supplier>? Suppliers { get; set; }
    public DbSet<StationaryStoreEmployee>? StationaryStoreEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=.;sql1=myDb;trusted_connection=true;");
        base.OnConfiguring(optionsBuilder);
    }
}