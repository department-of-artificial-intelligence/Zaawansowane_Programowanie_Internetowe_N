using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
        public string Country { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<StationaryStore> StationaryStores { get; set; }
    }
}