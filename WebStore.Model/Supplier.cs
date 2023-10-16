namespace WebStore.Model;

public class Supplier : User
{
    IList<Product>? Products { get; set; }
}