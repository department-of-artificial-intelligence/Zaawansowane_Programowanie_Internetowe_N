namespace WebStore.ViewModels.VM
{
    public class StationaryStoreVm
    {
        public int Id { get; set; }
        public virtual AddressVm? Address { get; set; }
        public string? Name { get; set; }
        public virtual IList<OrderVm>? Orders { get; set; }
        public virtual IList<InvoiceVm>? Invoices { get; set; }
        public virtual IList<StationaryStoreEmployeeVm>? StationaryStoreEmployees { get; set; }
        public virtual IList<StationaryStoreAddressVm>? StationaryStoreAdresses { get; set; }
    }

}