using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels;

public class StationaryStore
{
   public int Id { get; set; }
   public virtual Address Address {get; set;} = default!;
   
   [ForeignKey("Address")]
   public int AddressId { get; set; }
   public virtual IList<Order> Orders {get; set;} = default!;
   public long ArrangementNumber {get; set;} = default!;
   public virtual IList<StationaryStoreEmployee> StationaryStoreEmployees {get; set; } = default!;
}