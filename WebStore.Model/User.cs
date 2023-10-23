using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;

public abstract class User : IdentityUser<int>
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime RegistrationDate {get; set;}
}


