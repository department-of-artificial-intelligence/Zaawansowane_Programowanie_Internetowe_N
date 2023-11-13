using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewModels.ViewModels
{
    public class  LoginUserVm
    {
        #region properties
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength= 6)]
        [Display(Name = "Email")]
        public string Login { get; set; } = default!;
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = default!;
    #endregion
    }
}