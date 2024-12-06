namespace WebStore.Model
{
    public class Order
    {
        public int Id { get; set; } // Primary Key
        public int CustomerId { get; set; } // Foreign Key
        public int InvoiceId { get; set; } // Foreign Key
        public int StationaryStoreId { get; set; } // Foreign Key

        public Customer Customer { get; set; } = default!;
        public Invoice Invoice { get; set; } = default!;
        public StationaryStore StationaryStore { get; set; } = default!;

        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }
    }
}
