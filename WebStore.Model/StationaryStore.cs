namespace WebStore.Model;

public class StationaryStore
{
    public int Id { get; set; }
    public String? Country { get; set; }
    public String? Town { get; set; }
    public String? ZipCode { get; set; }
    public String? Street { get; set; }
    public int HouseNumber { get; set; }

    public ICollection<Address>? Addresses { get; set; }
    public ICollection<StationaryStoreEmployee>? StationaryStoreEmployees { get; set; }
}