using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Customer : User
    {
        
        //customer-address 1-m
        public IList<Address> Addresses { get; set; }
        //customer-Order 1-m
        public IList<Order> Orders { get; set; }
    }
}
