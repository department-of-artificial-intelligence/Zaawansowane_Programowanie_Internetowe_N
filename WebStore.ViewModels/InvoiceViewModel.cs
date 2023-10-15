namespace WebStore.ViewModels;

public class InvoiceViewModel
{
    public string InvoiceNumber { get; set; }
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public long TrackingNumber { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerFirstName { get; set; }
    public AddressViewModel BillingAddress { get; set; }
    public AddressViewModel ShippingAddress { get; set; }
    public IList<ProductViewModel> Products { get; set; }
}