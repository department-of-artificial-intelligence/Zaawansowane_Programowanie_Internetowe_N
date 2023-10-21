namespace WebStore.Model;

public class Category
{
    public int Id { get; set; }
    public String Name { get; set; }
    public String Tag { get; set; }
    public String? CategoryName { get; set; }
    public ICollection<Product>? Products { get; set; }
}