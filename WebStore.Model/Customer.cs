using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Model;

public class Customer : User
{ 
   public virtual Address? BillingAddress {get; set;} 
   public virtual Address? ShippingAddress {get; set;} 
   public virtual IList<Order> Orders {get; set;}  = new List<Order>();
}

