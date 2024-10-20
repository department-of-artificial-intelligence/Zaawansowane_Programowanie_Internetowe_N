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

}
