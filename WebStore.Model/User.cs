
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model;

public class User : IdentityUser
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime RegistrationDate {get; set;}
}


