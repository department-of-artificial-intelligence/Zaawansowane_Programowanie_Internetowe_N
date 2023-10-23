using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class Order{
    [Key][Required]
    public int Id {get; set;}
    public int CustomerId {get; set;}
    public virtual Customer Customer {get; set;}
    public DateTime DeliveryDate {get; set;}    
    public DateTime OrderDate {get; set;}
    public decimal TotalAmount {get;}
    public long TrackingNumber {get; set;}
    public int InvoiceId {get;set;}
    public virtual Invoice Invoice {get;set;}
    public virtual IList<Product> Products {get; set;}  = new List<Product>();
}
