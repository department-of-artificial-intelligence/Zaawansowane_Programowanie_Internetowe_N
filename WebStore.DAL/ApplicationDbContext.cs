using Microsoft.EntityFrameworkCore;
using WebStore.Model;

namespace WebStore.DAL;
public class ApplicationDbContext : DbContext
{
    public DbContextOptions _dbContext;
    
    public ApplicationDbContext(DbContextOptions dbContext)
    {
        _dbContext = dbContext;
    }
    public DbSet<AddressModel> Addresses { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<CustomerModel> Customers { get; set; }
    public DbSet<InvoiceModel> Invoices { get; set; }
    public DbSet<OrderModel> Orders { get; set; }
    public DbSet<OrderProductModel> OrderProducts { get; set; }
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<ProductStockModel> ProductStocks { get; set; }
    public DbSet<StationaryStoreModel> StationaryStores { get; set; }
    public DbSet<StationeryStoreEmployeeModel> StationaryStoreEmployees { get; set; }
    public DbSet<SupplierModel> Suppliers { get; set; }
    public DbSet<UserModel> Users { get; set; }
}
