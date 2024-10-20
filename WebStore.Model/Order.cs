using System;

namespace WebStore.Model;
public class Order
{
    public Customer Customer { get; set; }
    public DateTime DeliveryData { get; set; }
    public int Id { get; set; }
    public int OrderData { get; set; }
    public decimal TotalAmount { get; set; }
    public long TrackingNumber { get; set; }
}