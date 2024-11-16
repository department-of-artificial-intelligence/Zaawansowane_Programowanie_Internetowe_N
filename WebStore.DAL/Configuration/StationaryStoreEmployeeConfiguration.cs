using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class StationaryStoreEmployeeConfiguration : IEntityTypeConfiguration<StationaryStoreEmployee>
    {
        public void Configure(EntityTypeBuilder<StationaryStoreEmployee> builder)
        {
            builder.ToTable("StationaryStoreEmployees");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.EmployeeName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Position)
                   .IsRequired()
                   .HasMaxLength(100);

            // Inheritance Mapping (TPH)
            builder.HasBaseType<User>();

            // Relationship with StationaryStore via Shadow Foreign Key
            builder.HasOne<StationaryStore>()
                   .WithMany(ss => ss.Employees)
                   .HasForeignKey("StationaryStoreId")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
