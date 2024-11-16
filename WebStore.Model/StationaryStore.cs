namespace WebStore.Model
{
    public class StationaryStore
    {
        public int Id { get; set; } // Primary Key
        
        public int AddressId { get; set; } // Foreign Key
        
        public string StoreName { get; set; }
        
        public Address Location { get; set; } = default!;
        public List<StationaryStoreEmployee> Employees { get; set; } = new();
    }
}
