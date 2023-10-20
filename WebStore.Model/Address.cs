namespace WebStore.Model;

public class Address
{
    public String? BillingAddress { get; set; }
    public String? ShippingAddress { get; set; }
    public Customer? Customer { get; set; }

    public StationaryStore? StationaryStore { get; set; }
}