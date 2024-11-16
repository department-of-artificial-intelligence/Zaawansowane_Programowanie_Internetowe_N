using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Suppliers")]
<<<<<<< HEAD
public class Supplier : User
{
=======
public class Supplier
{
    [Key]
    public int Id { get; set; }

>>>>>>> 2949dc5d06da431d9635a2dc6bba840a7ce13767
    public virtual ICollection<OrderProduct> Products { get; set; } = new List<OrderProduct>();
}
