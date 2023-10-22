using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Address
    {
      [Key]
      public int Id {get;set;}
      public string City {get;set;}
      public string ZipCode {get;set;}
      public string Street {get; set;}
      public int BuildingNumber {get; set;}
      public int? ApartmentNumber {get; set;}
      public string Country {get; set;}
      public int CustomerId {get; set;}
      public Customer Customer {get; set;}
      public int StationaryStoreId {get; set;}
      public virtual StationaryStore StationaryStore {get;set;}
    }
}