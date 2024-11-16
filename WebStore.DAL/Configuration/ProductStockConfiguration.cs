using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.ToTable("ProductStocks");

            // Primary Key: ProductId (also Foreign Key to Product)
            builder.HasKey(ps => ps.ProductId);

            builder.Property(ps => ps.Quantity)
                   .IsRequired();

            // One-to-One: ProductStock has one Product
            builder.HasOne(ps => ps.Product)
                   .WithOne()
                   .HasForeignKey<ProductStock>(ps => ps.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
