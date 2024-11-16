using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class ProductStock
    {        
        public int Quantity { get; set; }

        public int IdProduct { get; set; }
        public Product Product { get; set; }
    }
}
