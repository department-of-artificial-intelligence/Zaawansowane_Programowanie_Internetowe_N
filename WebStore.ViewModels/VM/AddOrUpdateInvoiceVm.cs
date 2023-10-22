namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateInvoiceVm
    {
        public int? Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate {get; set;}
    }
}