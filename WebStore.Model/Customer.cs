namespace WebStore.Model;
public class Customer
{
    public string BillingAddress { get; set; }
    public Ilist<Order> Orders { get; set; }
    public string ShippingAddress { get; set; }
}
