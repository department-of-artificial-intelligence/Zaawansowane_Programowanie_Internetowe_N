using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
<<<<<<< HEAD
public class Customer : User
{
     public virtual ICollection<Order> Orders { get; set; }

     public virtual ICollection<Address> Addresses { get; set; }
=======
public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public DateTime RegistrationDate { get; set; }
>>>>>>> 2949dc5d06da431d9635a2dc6bba840a7ce13767

}
