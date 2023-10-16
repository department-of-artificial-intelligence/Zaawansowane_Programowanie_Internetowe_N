namespace WebStore.Model;
public class Order
{
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public long TrackingNumber { get; set; }
        public Customer? Customer { get; set; }
        public decimal TotalAmount { get;  }


}
