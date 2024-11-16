using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class StationaryStore
    {
        public IList<Address> Addresses { get; set; }
        public IList<StationaryStoreEmployee> StationaryStoreEmployes { get; set; }
    }
}
