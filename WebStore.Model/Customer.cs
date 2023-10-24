using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class Customer : User
{
    public virtual Address? BilingAddress {get; set;}
    public virtual Address? ShippingAddress {get; set;}
    public virtual IList<Order> Orders {get; set;} =  new List<Order>();    
}
