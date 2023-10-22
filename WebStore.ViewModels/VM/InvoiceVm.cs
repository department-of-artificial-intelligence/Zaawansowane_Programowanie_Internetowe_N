namespace WebStore.ViewModels.VM
{
    public class InvoiceVm
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate {get; set;}
        public IList<OrderVm> Orders {get; set;}
    }
}
