using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class StationaryStore
    {
        [Key]
        public int Id {get;set;}
        public string Name {get;set;}
        public virtual IList<Address> Addresses {get;set;} = new List<Address>();
        public virtual IList<StationaryStoreEmployee> StationaryStoreEmployees {get;set;} = new List<StationaryStoreEmployee>();     
    }
}