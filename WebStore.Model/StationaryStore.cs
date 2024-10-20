namespace WebStore.Model
{
    public class StationaryStore
    {
        public string StoreName { get; set; }
        public Address Location { get; set; }
        public List<StationaryStoreEmployee> Employees { get; set; }
    }
}
