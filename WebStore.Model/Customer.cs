using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Customer : User
    {
        public int Id {get; set;}
        public Address BillingAddress { get; set; }
        public IList<Order> Orders { get; set; }
        public Address ShippingAddress { get; set; }
    }
}