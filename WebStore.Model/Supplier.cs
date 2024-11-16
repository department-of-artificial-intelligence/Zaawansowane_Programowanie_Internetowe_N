using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Suppliers")]
public class Supplier
{
    [Key]
    public int Id { get; set; }

    public virtual ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();
}
