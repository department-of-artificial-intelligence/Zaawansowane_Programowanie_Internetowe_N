using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateOrderVm
    {
        public int? Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; }
        [Required]
        public long TrackingNumber { get; set; }
        [Required]
        public int InvoiceId { get; set; }

    }
}

