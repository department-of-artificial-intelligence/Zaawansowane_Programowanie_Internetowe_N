using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Model;

public class User
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegistrationDate { get; set; }
}