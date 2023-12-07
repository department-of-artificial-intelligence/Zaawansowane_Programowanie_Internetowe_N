using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class Product
{
    [Key][Required]
    public int Id {get; set;}  
    public string Description {get; set;}       
    public byte[]? ImageBytes {get; set;}  
    public string Name {get; set;}  
    public decimal Price {get; set;}  
    public float Weight {get; set;}  
    public int CategoryId {get; set;} 
    public Category Category {get; set;} 
    public int SupplierId {get; set;} 
    public Supplier Supplier {get; set;}  
    public IList<ProductStock> ProductStock {get; set;}  = new List<ProductStock>(); 
    public ICollection<Order> Orders {get; set;}  = new List<Order>(); 


}
//([Id], [Description], [ImageBytes], [Name], [Price], [Weight], [CategoryId], [SupplierId])