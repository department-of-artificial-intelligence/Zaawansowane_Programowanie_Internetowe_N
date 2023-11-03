namespace WebStore.ViewModels.VM
{
    public class OrderVm
    {
        public string Name { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; } 
        public int InvoiceNumber { get; set; } = default!;

    }
}
