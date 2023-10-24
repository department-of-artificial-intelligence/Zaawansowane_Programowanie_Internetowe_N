using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class StationaryStore 
{
   public int Id {get;set;}
   public string Name {get;set;}
   public IList<Address> Addresses {get;set;} = new List<Address>();
   public virtual IList<StationaryStoreEmployee> StationaryStoreEmployees {get;set;} = new List<StationaryStoreEmployee>();

}

