using System.ComponentModel.DataAnnotations;

namespace WebStore.Model;

public class Customer
{
    public string BillingAddress { get; set; }
    public IList<Order> Orders { get; set; }
    public Address ShippingAddress { get; set; }
}