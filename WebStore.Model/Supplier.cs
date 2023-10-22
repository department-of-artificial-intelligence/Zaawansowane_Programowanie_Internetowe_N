using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Model;

public class Supplier
{
    [Key]
    public int Id { get; set; }
    public IList<Product> Products { get; set; }
}