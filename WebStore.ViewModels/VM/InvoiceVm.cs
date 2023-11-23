namespace WebStore.ViewModels.VM
{
    public class InvoiceVm
    {
        public int Id { get; set; }
        public int? StationaryStoreId { get; set; }
        public virtual StationaryStoreVm? StationaryStore { get; set; }
        public DateTime Date { get; set; }
        public virtual IList<OrderVm>? Orders { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual CustomerVm? IssuedFor { get; set; }
    }

}

