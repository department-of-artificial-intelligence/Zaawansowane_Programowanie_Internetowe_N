namespace WebStore.Model;

public class Customer : User
{
    public String? BillingAddress { get; set; }
    public IList<Order>? Orders { get; set; }
    public String? ShippingAddress { get; set; }
}