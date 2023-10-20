namespace WebStore.Model;

public class Customer : User
{
    public Address? BillingAddress { get; set; }
    public Address? ShippingAddress { get; set; }

    public ICollection<Order>? Orders { get; set; }
    public ICollection<Address>? Addresses { get; set; }
}