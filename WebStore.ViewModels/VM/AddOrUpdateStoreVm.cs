namespace WebStore.ViewModels.VM;
using System.ComponentModel.DataAnnotations;

public class AddOrUpdateStoreVm
{
    [Required]
    public int? Id { get; set; }
    [Required]
    public string Name { get; set; } = default!;
}