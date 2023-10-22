using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.ViewModels
{
    public class UserVm
    {
        #region properties
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName {get;set;}
        #endregion
    }
}