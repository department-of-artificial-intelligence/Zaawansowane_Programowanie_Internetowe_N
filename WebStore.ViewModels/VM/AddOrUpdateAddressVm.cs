using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

 public class AddOrUpdateAddressVm
    {
        public int? Id { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? ZipCode { get; set; }
        [Required]
        public string? Street { get; set; }
        [Required]
        public int BuildingNumber { get; set; }
        [Required]
        public int? ApartmentNumber { get; set; }
    }

namespace WebStore.ViewModels.VM
{
    public class AddressVm
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}