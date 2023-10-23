using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model;
public class Supplier : User

{
    //     [Key]
    // public int Id {get; set;}
    public virtual IList<Product> Products {get; set;}  = new List<Product>();
}