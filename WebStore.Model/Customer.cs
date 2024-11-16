namespace WebStore.Model
{
    public class Customer : User
    {
        
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}
