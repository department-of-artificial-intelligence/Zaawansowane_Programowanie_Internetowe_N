using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class Customer : User
{
    //public virtual IList<Address> Addresses {get; set;} = new List<Address>();
    public virtual Address? BillingAddress {get; set;}
    public virtual Address? ShippingAddress {get; set;}
    public virtual IList<Order> Orders {get; set;} =  new List<Order>();    
}
