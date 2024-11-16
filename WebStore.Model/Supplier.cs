using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Suppliers")]
public class Supplier : User
{
    public virtual ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();
}
