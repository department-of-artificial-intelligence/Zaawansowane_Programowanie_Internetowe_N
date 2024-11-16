namespace WebStore.Model
{
    public class Customer : User
    {
        public Address BillingAddress { get; set; } = default!;
        public Address ShippingAddress { get; set; } = default!;
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
