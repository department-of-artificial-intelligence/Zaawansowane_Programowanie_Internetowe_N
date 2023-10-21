using Microsoft.AspNetCore.Identity;

namespace WebStore.Model;

public class User : IdentityUser<int>
{
    public int Id { get; set; }
    public String FirstName { get; set; }
    public String LastName { get; set; }

    public DateTime RegistrationDate { get; set; }
}