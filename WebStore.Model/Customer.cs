using System.ComponentModel.DataAnnotations;

namespace WebStore.Model;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public string BillingAddress { get; set; }
    public IList<Order> Orders { get; set; }
    public Address ShippingAddress { get; set; }
}