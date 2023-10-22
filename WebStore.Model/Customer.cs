using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStore.Model;

public class Customer : User
{ 
   [Key]
   public int Id {get; set;}
   public virtual IList<Address> Addresses {get; set;} = new List<Address>();
   public virtual IList<Order> Orders {get; set;}  = new List<Order>();
}

