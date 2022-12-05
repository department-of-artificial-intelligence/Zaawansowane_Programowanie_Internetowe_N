using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM

{
    public class AddOrUpdateInvoiceVm
    {
        public int? Id {get; set; }
        [Required]
        public int invoiceID {get; set;}
        [Required]
        public decimal totalPrice {get; set;} 
        [Required]
        public DateTime invoiceDate { get; set; } 
    }
}