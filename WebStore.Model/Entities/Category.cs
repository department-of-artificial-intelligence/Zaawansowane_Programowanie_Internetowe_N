using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.Entities.SubModels
{
    [Owned]
    public class Category
    {
        #region properties
        [Key]
        public int Id {get;set;}
        public string Name { get; set; }
        public virtual IList<Product> Products {get;set;} = new List<Product>();
        #endregion
    }
}