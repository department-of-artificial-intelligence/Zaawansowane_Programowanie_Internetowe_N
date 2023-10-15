using Microsoft.EntityFrameworkCore;

namespace WebStore.Model;

public class Supplier
{
    public IList<Product> Products { get; set; }
}