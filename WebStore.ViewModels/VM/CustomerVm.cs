using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels.VM;

namespace WebStore.ViewModels
{
    public class CustomerVm : UserVm
    {
        public IList<AddressVm> Addresses {get;set;} = new List<AddressVm>();
         public IList<OrderVm> Orders {get; set;} = new List<OrderVm>();
    }
}