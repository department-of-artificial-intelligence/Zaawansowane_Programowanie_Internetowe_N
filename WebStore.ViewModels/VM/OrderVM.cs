namespace WebStore.ViewModels.VM
{

    public class OrderVM
    {

        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; } = default!;
        public long TrackingNumber { get; set; } = default!;

    }

}
