namespace WebStore.Model
{
    public class Product
    {
        public int id { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Price { get; set; }
        public float Weight { get; set; }
        public List<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
        public int CategoryId { get; set; }
    }
}
