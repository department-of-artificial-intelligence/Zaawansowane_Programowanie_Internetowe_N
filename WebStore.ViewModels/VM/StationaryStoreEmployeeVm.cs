namespace WebStore.ViewModels.VM
{
    public class StationaryStoreEmployeeVm
    {
        public int StoreId { get; set; }
        public virtual StationaryStoreVm? Store { get; set; }
        public string? Title { get; set; }
        public decimal Pay { get; set; }
    }
}

