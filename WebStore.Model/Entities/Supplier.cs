using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.Entities
{
    public class Supplier : User
    {
        #region properties
        public virtual IList<Product> Products {get;set;} = new List<Product>();
        #endregion
    }
}