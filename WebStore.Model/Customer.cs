namespace WebStore.Model;
public class Customer
{
    public IList<Address> BillingAddress { get; set; }
    public Ilist<Order> Orders { get; set; }
    public IList<Address> ShippingAddress { get; set; }
}
