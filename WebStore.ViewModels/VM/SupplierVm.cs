using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class SupplierVm
    {
        public IList<ProductVm> Products { get; set; } = new List<ProductVm>();
    }
}