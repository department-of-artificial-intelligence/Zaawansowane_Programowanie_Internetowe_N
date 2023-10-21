using System.ComponentModel.DataAnnotations;
namespace WebStore.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public int PostalCode { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
    }
}