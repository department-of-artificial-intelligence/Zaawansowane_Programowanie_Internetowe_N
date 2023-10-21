namespace WebStore.Model
{
    public class Supplier : User
    {
        public virtual IList<Product>? Products { get; set; }
    }
}