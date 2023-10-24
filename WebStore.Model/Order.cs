using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public long TrackingNumber { get; set; }
        public int StationaryStoreId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual IList<Product> Products { get; set; } = new List<Product>();
    }
}
