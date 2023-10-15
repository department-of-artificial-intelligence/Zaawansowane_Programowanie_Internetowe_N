namespace WebStore.Model;
public class OrderProduct
{
     public IList<Order> Order { get; set; }
     public IList<Product> Product { get; set; }
     public int Quantity { get; set; }
}
