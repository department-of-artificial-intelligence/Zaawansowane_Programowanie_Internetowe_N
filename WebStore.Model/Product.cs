using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Product
    {
        
        public string Description { get; set; }
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight { get; set; }


        public int IdCategory { get; set; }
        public Category Category { get; set; }

        public int IdSupplier { get; set; }
        public Supplier Supplier { get; set; }

        public IList<ProductStock> ProductStocks { get; set; }

    }
}
