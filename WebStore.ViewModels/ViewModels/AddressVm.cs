using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.ViewModels
{
    public class AddressVm
    {
        #region properties
        public int? Id {get;set;}
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public CustomerVm Customer {get;set;}
        #endregion
    }
}