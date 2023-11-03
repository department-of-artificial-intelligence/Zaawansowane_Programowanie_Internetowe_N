using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateAddressVm
    {
        public int? Id { get; set; }
        [Required] 
        public string City { get; set; }
        [Required] 
        public string ZipCode { get; set; }
        [Required] 
        public string Street { get; set; }
        [Required]
        public int BuildingNumber { get; set; }
        [Required]
        public int ApartmentNumber { get; set; }
        [Required]
        public string Country { get; set; }
    }
}