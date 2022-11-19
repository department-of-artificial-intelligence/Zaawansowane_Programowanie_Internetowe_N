using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model.DataModels;

public class ProductStock
{
    public int Id { get; set; }
    public virtual Product Product {get; set;} = default!;
    [ForeignKey("Product")]
    public int ProductId {get; set; }
    public int Quantity {get; set;} 
}