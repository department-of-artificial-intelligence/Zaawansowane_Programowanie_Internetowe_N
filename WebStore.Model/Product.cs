using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Products")]
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Category { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public byte[] ImageBytes { get; set; }

    [Required]
    public string Name { get; set; }


    [Required]
    public double Price { get; set; }

    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }
    public virtual Supplier Supplier { get; set; }

    [Required]
    public float Weight { get; set; }

<<<<<<< HEAD
    public virtual ICollection<ProductStock> Stock { get; set; }

    public virtual ICollection<Product> Products { get; set; }

=======
>>>>>>> 2949dc5d06da431d9635a2dc6bba840a7ce13767
}
