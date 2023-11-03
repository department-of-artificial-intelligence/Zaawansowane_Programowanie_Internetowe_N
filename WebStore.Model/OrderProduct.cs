
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model
{
    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product? Product{ get; set; }
        public int Quantity{ get; set; }
    }
}