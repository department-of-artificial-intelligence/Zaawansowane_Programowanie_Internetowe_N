namespace WebStore.Model
{
    public class Invoice
    {
        public int Id {get; set;}
        public string? InvoiceNumber { get; set; }
        public int OrderId {get; set;}
        public Order? Order {get; set;}      
    }
}