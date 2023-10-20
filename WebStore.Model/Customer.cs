using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class Customer : User
{
    
    //public virtual IList<Address> BillingAddresses {get; set;} 
    public virtual IList<Order> Orders {get; set;}     
    //public virtual IList<Address> ShippingAddresses {get;set;} 
}
