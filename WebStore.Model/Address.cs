namespace WebStore.Model
{
    public class Address
    {
        public int Id { get; set; } // Primary Key
        
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string BuildingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string Country { get; set; }
    }
}
