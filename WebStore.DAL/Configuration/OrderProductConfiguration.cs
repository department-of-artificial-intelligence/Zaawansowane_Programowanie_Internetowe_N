using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("OrderProducts");

            // Composite Primary Key: OrderId + ProductId
            builder.HasKey(op => new { op.OrderId, op.ProductId });

            builder.Property(op => op.Quantity)
                   .IsRequired();

            // Many-to-One: OrderProduct belongs to Order
            builder.HasOne(op => op.Order)
                   .WithMany()
                   .HasForeignKey(op => op.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Many-to-One: OrderProduct belongs to Product
            builder.HasOne(op => op.Product)
                   .WithMany()
                   .HasForeignKey(op => op.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
