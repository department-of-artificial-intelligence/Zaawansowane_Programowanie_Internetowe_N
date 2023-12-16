using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class StationaryStore
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Address? Address { get; set; }
        public List<Customer>? Customers { get; set; }
        public List<StationaryStoreEmployee>? Employees { get; set; }
    }
}