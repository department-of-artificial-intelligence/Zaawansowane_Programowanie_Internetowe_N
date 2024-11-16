namespace WebStore.Model
{
    public class Order
    {
       

        public int id { get; set; }        
        public Customer Customer { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; }
        public Invoice Invoice { get; set; }
        public int CustomerId { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
