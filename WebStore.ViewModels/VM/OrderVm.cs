namespace WebStore.ViewModels.VM;

public class OrderVm
{
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public virtual CustomerVm Customer { get; set; }
        public int StationaryStoreId { get; set; }
        public virtual StationaryStoreVm StationaryStore { get; set; }
        public int? InvoiceId { get; set; }
        public virtual InvoiceVm Invoice { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; }
        public long TrackingNumber { get; set; }
        public virtual IList<ProductVm> Products { get; set; }
}
