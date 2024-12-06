using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Inheritance Mapping (TPH)
            builder.HasBaseType<User>();

            // One-to-Many: Customer has many Orders
            builder.HasMany(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
            
            // One-to-One: Customer has one BillingAddress
            builder.HasOne(c => c.BillingAddress)
                   .WithOne()
                   .HasForeignKey<Customer>(c => c.BillingAddressId)
                   .OnDelete(DeleteBehavior.Cascade);
            
            // One-to-One: Customer has one ShippingAddress
            builder.HasOne(c => c.ShippingAddress)
                   .WithOne()
                   .HasForeignKey<Customer>(c => c.ShippingAddressId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
