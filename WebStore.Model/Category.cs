using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Category
    {
        public IList<Product> Products { get; set; }
    }
}
