namespace WebStore.Model;
public class StationaryStoreEmployee : User
{
    public string JobTitle {get;set;}
    public int StationaryStoreId {get;set;}
    public virtual StationaryStore StationaryStore {get;set;}

}
