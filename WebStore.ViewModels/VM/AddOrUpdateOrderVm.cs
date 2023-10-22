using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateOrderVm
    {
        public int? Id {get; set;}
        [Required]
        public DateTime DeliveryDate { get; set; } = default!;
        [Required]
        public DateTime OrderDate { get; set; } = default!;
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public long TrackingNumber { get; set; }
        public int StationaryStoreId {get; set;}
        public int CustomerId { get; set; }
        public int InvoiceId {get; set;}
    }
}