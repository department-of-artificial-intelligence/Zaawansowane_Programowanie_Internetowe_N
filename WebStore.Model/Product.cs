namespace WebStore.Model;
public class Product
{
    public int Id {get; set;}  
    public string Description {get; set;}  
     
    public byte[] ImageBytes {get; set;}  
    public string Name {get; set;}  
    public decimal Price {get; set;}  
    public float Weight {get; set;}  
    public Category Category {get; set;} 
    public Supplier Supplier {get; set;}  
    public IList<ProductStock> ProductStock {get; set;}  
    public IList<Order> Orders {get; set;}  


}
//([Id], [Description], [ImageBytes], [Name], [Price], [Weight], [CategoryId], [SupplierId])