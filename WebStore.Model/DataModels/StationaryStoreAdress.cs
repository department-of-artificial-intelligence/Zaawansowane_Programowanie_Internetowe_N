namespace WebStore.Model.DataModels;
public class StationaryStoreAddress : Address
{
    public int StationaryStoreId { get; set; }
    public virtual StationaryStore StationaryStore { get; set; } = default!;
}