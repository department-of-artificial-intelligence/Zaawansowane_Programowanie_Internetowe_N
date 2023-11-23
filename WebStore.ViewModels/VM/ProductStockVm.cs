namespace WebStore.ViewModels.VM
{
    public class ProductStockVm
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual ProductVm? Product { get; set; }
        public int Quantity { get; set; }
    }

}
