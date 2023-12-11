using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebStore.ViewModels.VM
{
 public class AddOrUpdateStoreVm
    {
        public int? Id {get; set;}
        [Required]
        public string? Name { get; set; }
        [Required]
        public int AddressId {get; set;}

    }
}
namespace WebStore.ViewModels.VM
{
    public class StoreVm
    {
        
        public string? Name { get; set; }
        public int AddressId {get; set;}

    }
}