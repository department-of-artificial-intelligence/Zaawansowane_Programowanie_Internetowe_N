using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebStore.Model.Entities
{
    //[Owned]
    public class Invoice
    {
        #region properties
        [Key]
        public int Id {get;set;}
        public DateTime? DeliveryDate {get;set;}
        public DateTime? OrderDate {get;set;}
        public decimal? TotalAmount { get; set; }
        public long? TrackingNumber { get; set; }
        public virtual IList<Order>? Orders {get;set;} = new List<Order>();
        #endregion
    }
}