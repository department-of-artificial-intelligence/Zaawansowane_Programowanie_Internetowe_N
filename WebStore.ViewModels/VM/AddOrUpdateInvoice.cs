using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateInvoiceVm
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int? StationaryStoreId { get; set; }
    }
}