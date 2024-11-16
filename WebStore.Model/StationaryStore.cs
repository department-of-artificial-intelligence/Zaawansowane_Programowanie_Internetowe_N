namespace WebStore.Model;

[Table("StationaryStores")]
public class StationaryStore
{
    public virtual ICollection<Address> Addresses { get; set; }
}
