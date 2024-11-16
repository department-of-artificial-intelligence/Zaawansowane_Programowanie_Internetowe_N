namespace WebStore.Model
{
    public class StationaryStore:User
    {
        public int StoreId {  get; set; }
        public string StoreName { get; set; }
        public List<Address> AddressList { get; set; }=new List<Address>();
        public List<StationaryStoreEmployee> Employees { get; set; } = new List<StationaryStoreEmployee>();
    }
}
