

namespace WebStore.Model;
public class Order
{
   
    public DateTime DeliveryData { get; set; }
    public int Id { get; set; }
    public int OrderData { get; set; }
    public decimal TotalAmount { get; set; }
    public long TrackingNumber { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int OrderId { get; set; }
    public Invoice Invoice { get; set; }
}