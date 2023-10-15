using System.ComponentModel.DataAnnotations;

namespace WebStore.Model;

public class Invoice
{
    [Key]
    public int OrderId { get; set; }
    public string InvoiceNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public long TrackingNumber { get; set; }
    public string CustomerLastName { get; set; }
    public string CustomerFirstName { get; set; }
    public Address BillingAddress { get; set; }
    public Address ShippingAddress { get; set; }
    public IList<Product> Products { get; set; }
}