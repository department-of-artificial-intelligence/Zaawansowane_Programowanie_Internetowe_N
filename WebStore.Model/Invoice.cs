namespace WebStore.Model;

public class Invoice
{
    public int Id { get; set; }
    public Product? Product { get; set; }
    public int Quantity { get; set; }
    public float Price { get; set; }
    public decimal TotalAmount { get; set; }
    
    public ICollection<Order>? Orders { get; set; }
}