using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
public class Customer : User
{
     public virtual ICollection<Order> Orders { get; set; }

     public virtual ICollection<Address> Addresses { get; set; }

}
