using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Product
    {
        public string Category { get; set; }
        public string Description { get; set; } 
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Supplier Supplier { get; set; }
        public float Weight { get; set; }
        public IList<OrderProduct> Orders {get; set;}
    }
}