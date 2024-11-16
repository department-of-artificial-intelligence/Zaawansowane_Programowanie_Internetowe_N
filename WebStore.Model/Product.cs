namespace WebStore.Model
{
    public class Product
    {
        public int Id { get; set; } // Primary Key
        
        public int CategoryId { get; set; } // Foreign Key
        public int SupplierId { get; set; } // Foreign Key

        public string Description { get; set; }
        public string Name { get; set; }
        public byte[] ImageBytes { get; set; }
        public int Price { get; set; }
        public float Weight { get; set; }

        public Category Category { get; set; } = default!;
        public Supplier Supplier { get; set; } = default!;
    }
}
