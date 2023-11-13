using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.Entities
{
    public class StationaryStoreEmployee : User
    {
        #region properties
        public int? StationaryStoreId {get;set;}
        public virtual StationaryStore? StationaryStore {get;set;}
        #endregion
    }
}