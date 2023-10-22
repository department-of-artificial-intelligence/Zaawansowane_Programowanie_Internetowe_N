using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Model
{
    public class Invoice
    {
        [Key]
        public int Id {get; set;}
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate {get; set;}
        public virtual IList<Order> Orders {get; set;}      
    }
}