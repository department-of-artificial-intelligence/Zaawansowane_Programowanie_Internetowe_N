using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebStore.Model.Entities
{
    //[Owned]
    public class Address
    {
        #region properties
        [Key]
        public int Id {get;set;}
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public int CustomerId {get;set;}
        public virtual Customer Customer {get;set;}
        public int StationaryStoreId {get;set;}
        public virtual StationaryStore StationaryStore {get;set;}

        #endregion
    }
}