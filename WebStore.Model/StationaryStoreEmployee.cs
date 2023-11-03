using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System;
namespace WebStore.Model
{
    public class StationaryStoreEmployee : User
    {
        [ForeignKey("StationaryStore")]
        public int StationaryStoreId { get; set; }
        public virtual StationaryStore? StationaryStore { get; set; }
    }
}