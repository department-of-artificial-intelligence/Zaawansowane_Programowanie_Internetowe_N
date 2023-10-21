
namespace WebStore.Model
{
    public class Customer : User
    {
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public virtual IList<Order>? Orders { get; set; }
        public virtual IList<Address>? Addresses { get; set; }
    }
}