using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.Entities
{
    public class User : IdentityUser<int>
    {
        #region properties
        public string? FirstName { get; set; }
        public string? LastName {get;set;}
        public DateTime? RegistrationDate { get; set; }
        #endregion
    }
}