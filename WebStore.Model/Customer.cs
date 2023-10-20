using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebStore.Model;
public class Customer : User
{
        public IList<Address> Addresses { get;set; } = new List<Address>();
        public IList<Order> Orders {get;set;} = new List<Order>();

}
