namespace WebStore.Model;

public class StationaryStoreEmployee
{
    public int Id { get; set; }
    public String? Name { get; set; }
    public String? Surname { get; set; }
    public String? JobPosition { get; set; }
    

    public StationaryStore? StationaryStore { get; set; }
}