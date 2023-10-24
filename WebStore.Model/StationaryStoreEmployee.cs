using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class StationaryStoreEmployee : User
    {
         public string JobPosition {get;set;}
         public int StationaryStoreId {get; set;}
         public virtual StationaryStore StationaryStore {get;set;}
    }
}