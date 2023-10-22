using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Category
    {
        [Key]
        public int Id {get; set;}    
        public string Name { get; set; }
        public string Tag { get; set; }
        public virtual IList<Product> Products {get; set;} = new List<Product>();
    }
}