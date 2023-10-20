namespace WebStore.Model;

public class Category
{
    public int Id { get; set; }
    public String? CategoryName { get; set; }
    public ICollection<Product>? Products { get; set; }
}