using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public long TrackingNumber { get; set; }
        public int StationaryStoreId { get; set; }
        public int CustomerId { get; set; }
        public StationaryStore StationaryStore { get; set; }
        public Customer Customer { get; set; }
        public Invoice Invoice { get; set; }

        public IList<OrderProduct> OrderProducts { get; set; }
    }
}