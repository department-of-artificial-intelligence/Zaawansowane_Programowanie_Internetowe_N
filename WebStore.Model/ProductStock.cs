using System.ComponentModel.DataAnnotations;

namespace WebStore.Model;

public class ProductStock
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
}