using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class StationaryStoreVm
    {
        #region properties
        public int Id { get; set; }
        public virtual IList<AddressVm> Addresses {get;set;} = new List<AddressVm>();
        public virtual IList<StationaryStoreEmployeeVm> StationaryStoreEmployees {get;set;} = new List<StationaryStoreEmployeeVm>();
        #endregion
    }
}