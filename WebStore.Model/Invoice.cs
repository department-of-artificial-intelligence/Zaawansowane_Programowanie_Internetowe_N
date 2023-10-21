using System.ComponentModel.DataAnnotations;

namespace WebStore.Model
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public virtual IList<Order>? Orders { get; set; }
    }
}