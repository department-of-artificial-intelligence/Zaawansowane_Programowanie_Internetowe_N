using System.ComponentModel.DataAnnotations;

namespace WebStore.Model;

public class ProductStock
{
    [Key]
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}