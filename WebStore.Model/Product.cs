namespace WebStore.Model;
public class Product
{
<<<<<<< HEAD
    public Ilist<Category> Category { get; set; }
=======
    public string Category { get; set; }
>>>>>>> 448db946779aa6efb6a55670fa400d60f768d54e
    public string Description { get; set; }
    public int Id { get; set; }
    public byte[] ImageBytes { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Supplier Supplier { get; set; }
    public float Weight { get; set; }
<<<<<<< HEAD
}
=======
    public IList<OrderProduct> Orders { get; set; }
>>>>>>> 448db946779aa6efb6a55670fa400d60f768d54e
}
