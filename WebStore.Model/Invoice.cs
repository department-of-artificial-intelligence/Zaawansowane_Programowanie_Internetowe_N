using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("StationaryStore")]
        public int? StationaryStoreId { get; set; }
        public virtual StationaryStore? StationaryStore { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public virtual IList<Order>? Orders { get; set; }
        public virtual Customer? IssuedFor { get; set; }
    }
}