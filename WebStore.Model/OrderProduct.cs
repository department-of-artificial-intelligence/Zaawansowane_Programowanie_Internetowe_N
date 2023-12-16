using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class OrderProduct
    {
        public int Order {get; set;}
        public int Product{get;set;}
        public int Quantity{get; set;}
    }
}