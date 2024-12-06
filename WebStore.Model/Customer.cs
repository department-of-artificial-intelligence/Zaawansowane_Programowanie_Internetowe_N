namespace WebStore.Model
{
    public class Customer : User
    {
        public int BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }
        
        public Address BillingAddress { get; set; } = default!;
        public Address ShippingAddress { get; set; } = default!;
        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
