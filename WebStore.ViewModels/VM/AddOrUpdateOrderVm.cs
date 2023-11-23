using System.ComponentModel.DataAnnotations;
namespace WebStore.ViewModels.VM
{
    public class AddOrUpdateOrderVm
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public long TrackingNumber { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public int StationaryStoreId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int Invoiceid { get; set; }
    }

}
