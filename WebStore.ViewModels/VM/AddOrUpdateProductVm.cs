using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateProductVm
    {
        public int? Id { get; set; }
        [Required]
        public string Description { get; set; } = default!;
        [Required]
        public byte[] ImageBytes { get; set; } = default!;
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int SupplierId { get; set; }
    }
}
namespace WebStore.ViewModels.VM
{
    public class ProductVm
    {
        public string Description { get; set; } = default!;
        public byte[] ImageBytes { get; set; } = default!;
        public string Name { get; set; } = default!;
        public decimal Price { get; set; }
        public float Weight { get; set; }
        public int Quantity { get; set; }
    }
}