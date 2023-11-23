using System.ComponentModel.DataAnnotations;
namespace WebStore.Model
{
    public class StationaryStore
    {
        [Key]
        public int Id { get; set; }
        public virtual Address? Address { get; set; }
        public string? Name { get; set; }
        public virtual IList<Order>? Orders { get; set; }
        public virtual IList<Invoice>? Invoices { get; set;}
        public virtual IList<StationaryStoreEmployee>? StationaryStoreEmployees { get; set; }
        public virtual IList<StationaryStoreAddress>? StationaryStoreAddresses { get; set; }
    }
}