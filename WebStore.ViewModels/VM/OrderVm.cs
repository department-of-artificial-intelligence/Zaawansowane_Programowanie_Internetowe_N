using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Model;

namespace WebStore.ViewModels.VM
{
    public class OrderVm
    {
        public DateTime DeliveryDate { get; set; } = default!;
        public DateTime OrderDate { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public long TrackingNumber { get; set; } 
        public StationaryStoreVm StationaryStore {get; set;}
        public CustomerVm Customer {get; set;}
        public IList<ProductVm> Products { get; set;}
    }
}