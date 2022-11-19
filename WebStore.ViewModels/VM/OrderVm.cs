namespace WebStore.ViewModels.VM;
public class OrderVm
    {
        
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }

    }
