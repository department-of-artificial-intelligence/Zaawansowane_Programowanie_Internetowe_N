namespace WebStore.Model;

public class Supplier : User
{
    ICollection<Product>? Products { get; set; }
    public String UserName { get; set; }
    public String Email { get; set; }
}