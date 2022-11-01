using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels;

public class Category {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = default !;

    [Required]
    public string Tag { get; set; } = default !;
    public virtual IList<Product>? Products { get; set; }
}