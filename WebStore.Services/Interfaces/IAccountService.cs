using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(RegisterUserVm? registerUserVm);
    }
}