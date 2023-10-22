using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.VM
{
    public class UserVm
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName {get;set;}
    }
}