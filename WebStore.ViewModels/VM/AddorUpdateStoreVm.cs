using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateStoreVm
    {
        public int? Id { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public long ArrangementNumber { get; set; } = default!;
        
    }
}