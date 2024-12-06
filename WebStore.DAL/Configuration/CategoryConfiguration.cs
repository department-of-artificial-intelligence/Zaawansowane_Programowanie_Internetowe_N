using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebStore.Model;

namespace WebStore.DAL.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);

            // One-to-Many: Category has many Products
            builder.HasMany<Product>()
                   .WithOne(p => p.Category)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
            
            // One-to-Many: Category has many tags (List<string>) and value comparer
            builder.Property(c => c.Tags)
                   .HasConversion(
                       tags => string.Join(',', tags),
                       tags => tags.Split(',', StringSplitOptions.RemoveEmptyEntries))
                   .Metadata.SetValueComparer(
                       new ValueComparer<IList<string>>(
                           (c1, c2) => c1.SequenceEqual(c2),
                           c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                           c => c.ToArray()));
        }
    }
}
