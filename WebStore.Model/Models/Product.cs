using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace WebStore.Model
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        public String Category { get; set; }

        public String Description { get; set; }

        public Byte[] ImageBytes { get; set; } 

        public String Name { get; set; }

        public decimal Price { get; set; }

        public Supplier Supplier { get; set; }

        public float Weight { get; set; }
    }
}