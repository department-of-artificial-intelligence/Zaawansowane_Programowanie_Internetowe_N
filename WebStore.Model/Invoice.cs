namespace WebStore.Model
{
    public class Invoice
    {
       
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
