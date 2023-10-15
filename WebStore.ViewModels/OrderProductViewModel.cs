using System.Reflection.Metadata.Ecma335;

namespace WebStore.ViewModels;

public class OrderProductViewModel
{
    public OrderViewModel OrderViewModel { get; set; }
    public ProductViewModel ProductViewModel { get; set; }
    public int Quantity { get; set; }
}