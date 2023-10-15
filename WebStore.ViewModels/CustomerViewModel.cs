namespace WebStore.ViewModels;

public class CustomerViewModel
{
    public string BillingAddress { get; set; }
    public IList<OrderViewModel> Orders { get; set; }
    public AddressViewModel ShippingAddressViewModel { get; set; }
}