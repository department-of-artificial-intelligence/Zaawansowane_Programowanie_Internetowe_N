using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class InvoiceVm
    {
        #region properties
        public int Id {get;set;}
        public DateTime DeliveryDate {get;set;}
        public DateTime OrderDate {get;set;}
        public decimal TotalAmount { get; set; }
        [Required]
        public long TrackingNumber { get; set; }
        #endregion  
    }
}