using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebStore.Model;

public class StationaryStore
{
    [Key]
    public int Id { get; set; }
    public Address StoreAddress  { get; set; }
}