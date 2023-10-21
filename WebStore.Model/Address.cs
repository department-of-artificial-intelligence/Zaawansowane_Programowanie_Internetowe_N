namespace WebStore.Model;

public class Address
{
    public int Id { get; set; }
    public String? BillingAddress { get; set; }
    public String? ShippingAddress { get; set; }
    public Customer? Customer { get; set; }

    public StationaryStore? StationaryStore { get; set; }
}