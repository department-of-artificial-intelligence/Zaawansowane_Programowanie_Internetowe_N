
using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM

{
    public class DeleteOrderVm
    {
        [Required]
        public int? Id { get; set; }

    }
}