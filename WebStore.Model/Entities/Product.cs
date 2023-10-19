using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Model.Entities
{
    public class Product
    {
        #region properties
        [Key]
        public int Id { get;set; }
        public int Quantity {get;set;}
        public string Description {get;set;}
        public byte[] ImageBytes { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Weight {get;set;}
        public int CategoryId {get;set;}
        public virtual Category Category { get; set; }
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual IList<ProductStock> ProductStocks {get;set;} = new List<ProductStock>();
        public virtual IList<Order> Orders {get;set;} = new List<Order>();
        
        #endregion
    }
}