namespace WebStore.Model;

public class ProductStock
{
    public int Id { get; set; }
    public Product? Product { get; set; }
    public int Quanitity { get; set; }

    public ICollection<Product>? Products { get; set; }
}