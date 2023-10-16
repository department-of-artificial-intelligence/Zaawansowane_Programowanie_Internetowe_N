using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class StationaryStore
    {
        public int Id {get; set;}
        public string Name { get; set; }
        public int AddressId {get; set;}
        public Address Address { get; set; }  
        public IList<Customer> Customers {get; set;}       
    }
}