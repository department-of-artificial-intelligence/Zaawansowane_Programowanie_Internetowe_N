using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.ViewModels
{
    public class RegisterUserVm
    {
        #region properties
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        #endregion
    }
}