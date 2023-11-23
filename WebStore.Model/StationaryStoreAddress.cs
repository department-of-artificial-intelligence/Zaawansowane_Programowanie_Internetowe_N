using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Model
{
    public class StationaryStoreAddress : Address
    {
        [ForeignKey("StationaryStoreAddress")]
        public int StationaryStoreId { get; set; }
        public virtual StationaryStore? StationaryStore { get; set; }
    }
}