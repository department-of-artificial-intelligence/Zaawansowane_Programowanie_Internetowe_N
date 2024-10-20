using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ProductsStock")]
public class ProductStock
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    [Required]
    public int Quantity { get; set; }

}
