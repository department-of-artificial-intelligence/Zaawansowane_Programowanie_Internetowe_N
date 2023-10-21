using System.ComponentModel.DataAnnotations;
namespace WebStore.Model
{
    public class StationaryStore
    {
        [Key]
        public int Id { get; set; }
        public virtual IList<Address>? Addresses { get; set; }
        public virtual IList<StationaryStoreEmployee>? StationaryStoreEmployees { get; set; }
    }
}