using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebStore.Model.VM
{
    public class User
    {
        public string? FirstName {get;set;}
        public string? LastName {get;set;}
        public DateTime RegistrationDate{get;set;}


        
        }
        public class Customer
        {
            public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public Address? BillingAddress { get; set; }
        public Address? ShippingAddress { get; set; }
        public List<Order>? Orders { get; set; }
        }
        public class Supplier
        {
            ICollection<Product>? Products { get; set; }
            public String UserName { get; set; }
            public String Email { get; set; }
           
        }
    }
