using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace WebStore.ViewModels.VM
{
 public class AddOrUpdateInvoiceVm
    {
        public int? Id { get; set; }
        [Required]
        public string? InvoiceNumber { get; set; }
        [Required]
        public int OrderId {get; set;}
    }
}
namespace WebStore.ViewModels.VM
{
    public class InvoiceVm
    {
        public string? InvoiceNumber { get; set; }
        public int OrderId {get; set;}
    }
}