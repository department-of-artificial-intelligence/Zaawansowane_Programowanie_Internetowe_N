namespace WebStore.ViewModels;

public class OrderViewModel
{
    public CustomerViewModel CustomerViewModel { get; set; }
    public DateTime DeliveryDate { get; set; }
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; }
    public long TrackingNumber { get; set; }
    public InvoiceViewModel InvoiceViewModel { get; set; }
}