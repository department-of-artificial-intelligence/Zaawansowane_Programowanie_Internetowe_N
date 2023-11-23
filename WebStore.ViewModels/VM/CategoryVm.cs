namespace WebStore.ViewModels.VM
{
    public class CategoryVm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Tag { get; set; }
        public virtual IList<ProductVm>? Products { get; set; }
    }

}

