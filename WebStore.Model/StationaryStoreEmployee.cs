namespace WebStore.Model
{
    public class StationaryStoreEmployee : User
    {
        public int Id { get; set; } // Primary Key
        
        public string EmployeeName { get; set; }
        public string Position { get; set; }
    }
}
