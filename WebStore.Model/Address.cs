namespace WebStore.Model;
public class Address 
{
    public int Id {get;set;}
    public string City {get;set;}
    public string ZipCode {get;set;}
    public string Street {get; set;}
    public int BuildingNumber {get; set;}
    public int ApartmentNumber {get; set;}
    public string Country {get; set;}
    
    //must be nullable to allow for multiple reference types <store> or <user>, never both at once
    //defining those references as class properties forces those relations to be non-nullable
    // public int StationaryStoreId {get;set;}
    // public virtual StationaryStore StationaryStore {get;set;}
    // public int CustomerId {get;set;}
    // public virtual Customer Customer {get;set;}
}
