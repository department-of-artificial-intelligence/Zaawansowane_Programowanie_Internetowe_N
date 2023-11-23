using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebStore.Model
{
    public class Customer : User
    {
        public string? BillingAddress { get; set; }
        public string? ShippingAddress { get; set; }
        public virtual IList<Order>? Orders { get; set; }
        public virtual IList<CustomerAddress>? CustomerAddresses { get; set; }
    }
}