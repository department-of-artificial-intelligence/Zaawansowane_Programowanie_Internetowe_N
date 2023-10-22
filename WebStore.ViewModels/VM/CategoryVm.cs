using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class CategoryVm
    {  
        public string Name { get; set; }
        public string Tag { get; set; }
        public IList<ProductVm> Products {get; set;}
    }
}