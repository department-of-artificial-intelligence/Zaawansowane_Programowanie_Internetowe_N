namespace WebStore.Model;

public class Supplier : User
{
    ICollection<Product>? Products { get; set; }
}