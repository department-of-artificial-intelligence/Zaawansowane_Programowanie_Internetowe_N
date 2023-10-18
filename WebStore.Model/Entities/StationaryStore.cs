using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.Entities
{
    public class StationaryStore
    {
        #region properties
        public int Id { get; set; }
        public virtual IList<Address> Addresses {get;set;} = new List<Address>();
        public virtual IList<StationaryStoreEmployee> StationaryStoreEmployees {get;set;} = new List<StationaryStoreEmployee>();
        #endregion
    }
}