using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Persistence;
using WebStore.Model.Entities;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Services.ConcreteServices
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger, IPasswordHasher<User> passwordHasher) : base(dbContext, mapper, logger)
        {
            _passwordHasher =passwordHasher;
        }

        public async Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(RegisterUserVm? registerUserVm)
        {
            try
            {
                if (registerUserVm is null)
                    return (false, "Incorrect model uploaded");

                var newUserEntity = _mapper.Map<User>(registerUserVm);
                var hashedPassword = _passwordHasher.HashPassword(newUserEntity, registerUserVm.Password);
                newUserEntity.PasswordHash = hashedPassword;

                //await UserManager<User>.CreateAsync(newUserEntity, registerUserVm.Password);
                //if (createdResult.Succeeded)
                //{
                //    await UserManager<User>.AddToRoleAsync(newUserEntity.Id, "Manager");
                //}

                await _dbContext.Users.AddAsync(newUserEntity);
                await _dbContext.SaveChangesAsync();
                return (true, "Successfully created account");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }
    }
}