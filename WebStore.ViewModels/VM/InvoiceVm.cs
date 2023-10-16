namespace WebStore.ViewModels.VM
{
    public class InvoiceVm
    {
        public string InvoiceNumber { get; set; }
        public int OrderId { get; set; }
        public OrderVm Order { get; set; }
    }
}
