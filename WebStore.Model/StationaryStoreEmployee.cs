namespace WebStore.Model;

[Table("StationaryStores")]
public class StationaryStoreEmployee : User
{
    public virtual ICollection<Address> Addresses { get; set; }
}
