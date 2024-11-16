namespace WebStore.Model
{
    public class Supplier
    {
        public int Id { get; set; } // Primary Key

        public List<Product> Products { get; set; } = new();
    }
}
