namespace WebStore.ViewModels.VM;
public class OrderVm
    {
        
        public DateTime DeliveryDate { get; set; }
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }
        public int Invoiceid { get; set; } = default!;
        public int CustomerId { get; set; }

    }