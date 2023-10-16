using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Category
    {
        public int Id {get; set;}    
        public string Name { get; set; }
        public string Tag { get; set; }
        public IList<Product> Products {get; set;}
    }
}