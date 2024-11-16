namespace WebStore.Model
{
    public class ProductStock
    {
        public int ProductId { get; set; } // Primary and Foreign Key
        
        public int Quantity { get; set; }

        public Product Product { get; set; } = default!;
    }
}
