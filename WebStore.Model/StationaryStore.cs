namespace WebStore.Model;
public class StationaryStore
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IList<Address> Address { get; set; }
}
