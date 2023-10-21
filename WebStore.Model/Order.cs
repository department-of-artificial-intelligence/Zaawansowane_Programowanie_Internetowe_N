
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get ; set; }

        [ForeignKey("StationaryStore")]
        public int? StationaryStoreId { get; set; }
        public virtual StationaryStore? StationaryStore { get; set; }
        
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public virtual Invoice? Invoice { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public long TrackingNumber { get; set; }
    }
}