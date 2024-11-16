namespace WebStore.Model
{
    public class StationaryStoreEmployee:User
    {
        public string EmployeeName { get; set; }
        public string Position { get; set; }
        public int StoreId {  get; set; }
        public StationaryStore StationaryStore { get; set; }
    }
}
