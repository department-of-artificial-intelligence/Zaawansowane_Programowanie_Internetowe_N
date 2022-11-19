using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class AddressVm
    {
        public string StreetName { get; set; } = default!;
        public int StreetNumber { get; set; } = default!;
        public string City { get; set; } = default!;
        public int PostCode { get; set; } = default!;

    }
}