namespace WebStore.Model
{
    public class Invoice
    {
        public int OrderId { get; set; } // Primary and Foreign Key
        
        public DateTime InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        
        public Order Order { get; set; } = default!;
    }
}
