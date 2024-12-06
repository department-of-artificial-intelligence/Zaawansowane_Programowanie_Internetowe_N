using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class StationaryStoreConfiguration : IEntityTypeConfiguration<StationaryStore>
    {
        public void Configure(EntityTypeBuilder<StationaryStore> builder)
        {
            builder.ToTable("StationaryStores");

            builder.HasKey(ss => ss.Id);

            builder.Property(ss => ss.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            // Foreign Key: AddressId references Address
            builder.HasOne(ss => ss.Location)
                   .WithMany()
                   .HasForeignKey(ss => ss.AddressId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: StationaryStore has many StationaryStoreEmployees
            builder.HasMany(ss => ss.Employees)
                   .WithOne()
                   .HasForeignKey("StationaryStoreId") // Shadow foreign key
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
