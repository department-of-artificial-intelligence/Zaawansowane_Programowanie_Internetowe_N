namespace WebStore.Model
{
    public class OrderProduct
    {
        public int OrderId { get; set; } // Foreign Key
        public int ProductId { get; set; } // Foreign Key

        public int Quantity { get; set; }

        public Order Order { get; set; } = default!;
        public Product Product { get; set; } = default!;
    }
}
