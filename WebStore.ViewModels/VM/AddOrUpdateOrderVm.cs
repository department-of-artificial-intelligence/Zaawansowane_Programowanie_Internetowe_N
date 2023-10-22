using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebStore.ViewModels.VM
{
 public class AddOrUpdateOrderVm
    {
        public int? Id { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public long TrackingNumber { get; set; }
    }
}
namespace WebStore.ViewModels.VM
{
    public class OrderVm
    {

        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public long TrackingNumber { get; set; }

    }
}