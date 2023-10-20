namespace WebStore.Model;

public class Product
{

    public String? Description { get; set; }
    public int Id { get; set; }
    public byte[]? ImageBytes { get; set; }
    public String? Name { get; set; }
    public decimal Price { get; set; }
    public float Weight { get; set; }

    public Supplier? Supplier { get; set; }
    public Category? Category { get; set; }
    public ICollection<Order>? Orders { get; set; }
}