using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels.VM;

namespace WebStore.Model
{
    public class StationaryStoreVm
    {
        public int? Id {get; set;}
        public string Name { get; set; }
        public int AddressId {get; set;} 
        public int CustomerId {get; set; }      
    }
}