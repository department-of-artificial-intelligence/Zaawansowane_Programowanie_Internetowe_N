namespace WebStore.Model
{
    public class Category
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IList<string> Tags { get; set; } = new List<string>();
    }
}
