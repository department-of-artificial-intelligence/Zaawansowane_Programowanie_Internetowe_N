
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public virtual Supplier? Supplier { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public string? Description { get; set; }
        public byte[]? ImageBytes { get; set; }
        public string? Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public virtual IList<ProductStock>? ProductStocks { get; set; }
        public virtual IList<OrderProduct>? OrderProducts { get; set; }
    }
}