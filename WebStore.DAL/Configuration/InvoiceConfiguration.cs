using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices");

            // Primary Key: OrderId (also Foreign Key to Order)
            builder.HasKey(i => i.OrderId);

            builder.Property(i => i.InvoiceDate)
                   .IsRequired();

            builder.Property(i => i.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(20);

            builder.Property(i => i.TotalAmount)
                   .HasPrecision(18, 2)
                   .IsRequired();

            // One-to-One: Invoice has one Order
            builder.HasOne(i => i.Order)
                   .WithOne(o => o.Invoice)
                   .HasForeignKey<Invoice>(i => i.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
