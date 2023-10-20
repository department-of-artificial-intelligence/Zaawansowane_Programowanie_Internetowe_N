using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class Order{
    [Key][Required]
    public int Id {get; set;}
    public Customer Customer {get; set;}
    public DateTime DeliveryDate {get; set;}    
    public DateTime OrderDate {get; set;}
    public decimal TotalAmount {get;}
    public long TrackingNumber {get; set;}
    public Invoice Invoice {get;set;}
    public ICollection<Product> Products {get; set;}  
}
