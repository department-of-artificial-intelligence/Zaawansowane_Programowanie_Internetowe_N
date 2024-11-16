using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class StationaryStoreEmployee
    {
        public int IdStationaryStore { get; set; }
        public StationaryStore StationaryStore { get; set; }
    }
}
