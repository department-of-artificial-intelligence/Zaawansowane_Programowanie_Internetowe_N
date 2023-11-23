namespace WebStore.ViewModels.VM
{
    public class CustomerAddressVm
    {
        public int CustomerId { get; set; }
        public virtual CustomerVm? Customer { get; set; }
        
    }

}

