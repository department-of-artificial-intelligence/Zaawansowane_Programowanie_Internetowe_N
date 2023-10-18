using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model.Entities
{
    public class ProductStock
    {
        #region properties
        [Key]
        public int Id {get;set;}
        public int Quantity
        public Id ProductId {get;set;}
        public virtual Product Product {get;set;}
        #endregion
    }
}