using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.Entities
{
    public class Order
    {
        #region properties
        [Key]
        public int Id {get;set;}
        public DateTime DeliveryDate {get;set;}
        public DateTime OrderDate {get;set;}
        public decimal TotalAmount {get;set;}
        public long TrackingNumber{get;set;}
        public virtual Customer Customer {get;set;}
        public int InvoiceId {get;set;}
        public virtual Invoice Invoice {get;set;}
        public virtual IList<Product> Products {get;set;} = new List<Products>();

        #endregion
    }
}