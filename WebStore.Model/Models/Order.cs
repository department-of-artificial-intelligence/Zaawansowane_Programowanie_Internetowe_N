using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace WebStore.Model
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public DateTime DeliveryDate { get; set; }
        
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public long TrackingNumber { get; set; }
    }
}