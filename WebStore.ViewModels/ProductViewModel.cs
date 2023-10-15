namespace WebStore.ViewModels;

public class ProductViewModel
{
    public CategoryViewModel CategoryViewModel { get; set; }
    public string Description { get; set; }
    public int Id { get; set; }
    public byte[] ImageBytes { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public SupplierViewModel SupplierViewModel { get; set; }
    public float Weight { get; set; }
}