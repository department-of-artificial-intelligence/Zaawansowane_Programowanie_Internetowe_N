using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebStore.Model.Entities;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

namespace WebStore.Web.Controllers
{
    
    public class AccountApiController : BaseApiController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly JwtOptionsVm _jwtOptions;
        private readonly IAccountService _accountService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountApiController(ILogger logger,
        IMapper mapper,
        IOptions<JwtOptionsVm> jwtOptions,
        SignInManager<User> signInManager, UserManager<User> userManager,
        IAccountService accountService, IPasswordHasher<User> passwordHasher) : base(logger, mapper)
        {
        _jwtOptions = jwtOptions.Value;
        _signInManager = signInManager;
        _userManager = userManager;
        _accountService = accountService;
        _passwordHasher = passwordHasher;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserAsync([FromForm] RegisterUserVm registerUserVm){

            try
            {
                if (registerUserVm is null)
                {
                    ModelState.AddModelError("Model", "Incorrect model uploaded");
                    return BadRequest(ModelState);
                }
                var newUserEntity = Mapper.Map<User>(registerUserVm);
                newUserEntity.UserName = registerUserVm.Email; //nalezy uzupelnic
                //var hashedPassword = _passwordHasher.HashPassword(newUserEntity, registerUserVm.Password);
                //newUserEntity.PasswordHash = hashedPassword;
                newUserEntity.EmailConfirmed = true;
                
                var createdResult = await _userManager.CreateAsync(newUserEntity, registerUserVm.Password);
                
                if (createdResult.Succeeded)
                {
                    
                    await _userManager.AddToRoleAsync(newUserEntity, "Manager");
                    return Ok("Successfully created account");
                }
                
                ModelState.AddModelError("Database","Error occured while added to database");
                return BadRequest(ModelState);



            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                return BadRequest("Error occurred");
            }

        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm] LoginUserVm applicationUser)
        {
        try
        {
        if (applicationUser == null ||
        ModelState == null ||
        !ModelState.IsValid)
        {
        Logger.LogInformation($"Model is invalid");
        return BadRequest("Invalid credentials");
        }
        
        var result = await _signInManager.PasswordSignInAsync(applicationUser.Login, applicationUser.Password, true, false);
               //var aaa= await _userManager.FindByEmailAsync(applicationUser.Login);
                
        if (result.Succeeded == false)
        {
        Logger.LogInformation($"Invalid username ({applicationUser.Login}) or password ({applicationUser.Password})");
        return BadRequest("Invalid credentials");
        }
        var user = await _userManager.FindByEmailAsync(applicationUser.Login);
        var userRoles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim> {
        new Claim (ClaimTypes.Name, applicationUser.Login),
        new Claim (JwtRegisteredClaimNames.Nbf,
        new DateTimeOffset (DateTime.Now).ToUnixTimeSeconds ().ToString ()),
        new Claim (JwtRegisteredClaimNames.Exp,
        ((long) ((DateTime.Now.AddMinutes (_jwtOptions.TokenExpirationMinutes) - new DateTime (1970, 1, 1, 0, 0,
        0)).TotalSeconds)).ToString ())
        };
        claims.AddRange(userRoles.Select(ur => new Claim(ClaimTypes.Role, ur)));
        var token = new JwtSecurityToken(
        new JwtHeader(new SigningCredentials(
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
        SecurityAlgorithms.HmacSha256)),
        new JwtPayload(claims));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
        var response = new
        {
        access_token = encodedJwt,
        expires_in = token.ValidTo.ToString("yyyy-MM-ddTHH:mm:ss")
        };
        return Ok(response);
        }
        catch (Exception ex)
        {
        Logger.LogError(ex, ex.Message);
        return BadRequest("Error occurred");
        }
        }
        }
}