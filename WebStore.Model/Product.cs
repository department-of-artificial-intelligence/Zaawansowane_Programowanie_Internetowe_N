namespace WebStore.Model;
public class Product
{
    public string? Description { get; set; }
    public int? Id { get; set; }
    public byte[]? ImageBytes { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public Supplier? Supplier { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public float? Weight { get; set; }
}

