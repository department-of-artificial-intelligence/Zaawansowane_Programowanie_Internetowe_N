namespace WebStore.Model
{
    public class Customer : User
    {
        
        public Address BillingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public List<Order> Orders { get; set; }
    }
}
