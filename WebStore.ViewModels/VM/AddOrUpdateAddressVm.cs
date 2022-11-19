using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateAddressVm
    {
        public int? Id { get; set; }
        [Required]
        public string StreetName { get; set; } = default!;
        [Required]
        public int StreetNumber { get; set; } 
        [Required]
        public string City { get; set; } = default!;
        [Required]
        public string PostCode { get; set; } = default!;

    }
}