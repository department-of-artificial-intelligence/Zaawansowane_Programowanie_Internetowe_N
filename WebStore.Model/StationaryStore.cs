using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class StationaryStore 
{
   public int Id {get;set;}
   public string Name {get;set;}
   public virtual IList<Address> Address {get;set;} = new List<Address>();
   public virtual IList<StationaryStoreEmployee> StationaryStoreEmployees {get;set;} = new List<StationaryStoreEmployee>();

}

// INSERT [dbo].[StationaryStores] ([Id], [Name], [AddressId]) VALUES (1, N'Our Store', 1)
