namespace WebStore.Model;
public class StationaryStore 
{
   public int Id {get;set;}
   public string Name {get;set;}
   public IList<Address> Address {get;set;}
   public IList<StationaryStoreEmployee> StationaryStoreEmployees {get;set;}

}

// INSERT [dbo].[StationaryStores] ([Id], [Name], [AddressId]) VALUES (1, N'Our Store', 1)
