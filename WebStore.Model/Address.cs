using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Address
    {

        public int IdCustomer { get; set; }
        public Customer Customer { get; set; }

        public int IdStationaryStore { get; set; }
        public StationaryStore StationaryStore { get; set; }
    }
}
