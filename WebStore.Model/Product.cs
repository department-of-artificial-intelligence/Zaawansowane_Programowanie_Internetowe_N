using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public IList<ProductStock> Stocks { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; 
    }
 }
}
