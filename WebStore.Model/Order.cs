namespace WebStore.Model;

public class Order
{

    public DateTime DeliveryDate { get; set; }
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public long TrackingNumber { get; set; }

    public Customer? Customer { get; set; }
    public Invoice? Invoice { get; set; }
    public ICollection<Product>? Products { get; set; }
}