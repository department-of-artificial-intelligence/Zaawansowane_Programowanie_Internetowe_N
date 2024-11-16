using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.RegistrationDate)
                   .IsRequired();

            // Inheritance Mapping using TPH (Table-Per-Hierarchy)
            builder.HasDiscriminator<string>("UserType")
                   .HasValue<User>("User")
                   .HasValue<Customer>("Customer")
                   .HasValue<StationaryStoreEmployee>("StationaryStoreEmployee");
        }
    }
}
