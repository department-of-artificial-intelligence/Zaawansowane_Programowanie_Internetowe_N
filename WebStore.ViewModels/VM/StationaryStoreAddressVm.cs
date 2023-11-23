namespace WebStore.ViewModels.VM
{
    public class StationaryStoreAddressVm
    {
        public int StationaryStoreId { get; set; }
        public virtual StationaryStoreVm? StationaryStore { get; set; }
    }
}