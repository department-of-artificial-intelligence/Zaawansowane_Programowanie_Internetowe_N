namespace WebStore.Model
{
    public class Address
    {
     
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Customer Customer { get; set; }
        public StationaryStore StationaryStore { get; set; } 
    }
}
