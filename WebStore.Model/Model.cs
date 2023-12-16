using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace WebStore.Model;

public class StationaryStore
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Address Location { get; set; }
    public IList<StationaryStoreEmployee> Employees { get; set; }
}

public class StationaryStoreEmployee : User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int StoreId { get; set; } // Klucz obcy dla StationaryStore
    public virtual StationaryStore Store { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Product> Products { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public float Weight { get; set; }
    public byte[] ImageBytes { get; set; }
    public int SupplierId { get; set; } // Klucz obcy dla Supplier
    public virtual Supplier Supplier { get; set; }
    public virtual ProductStock ProductStock { get; set; } // Dla relacji one-to-one z ProductStock
    public int CategoryId { get; set; } // Klucz obcy dla Category
    public virtual Category Category { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } // Dla relacji many-to-many z Order
}
public class Invoice
{
    public int Id { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime DateIssued { get; set; }
    public decimal Amount { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}




public class Address
{
    public int Id { get; set; } // Klucz główny
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
}

// User class
public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime RegistrationDate { get; set; }
}

// Customer class
public class Customer : User
{
    public virtual  Address BillingAddress { get; set; }
    public virtual  Address ShippingAddress { get; set; }
    public virtual  IList<Order> Orders { get; set; }
}


// Supplier class
public class Supplier : User
{
    public IList<Product> Products { get; set; }
}

// Order class
public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime DeliveryDate { get; set; }
    public decimal TotalAmount { get; set; }
    public long TrackingNumber { get; set; }
    public int InvoiceId { get; set; } // Klucz obcy
    public virtual Invoice Invoice { get; set; }
    public int CustomerId { get; set; } // Klucz obcy dla Customer
    public virtual Customer Customer { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } // Dla relacji many-to-many z Product
}


// OrderProduct class
public class OrderProduct
{
    public int OrderId { get; set; } // Klucz obcy dla Order
    public virtual Order Order { get; set; }
    public int ProductId { get; set; } // Klucz obcy dla Product
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
}

// ProductStock class
public class ProductStock
{   
    public int Id { get; set; }
    public int ProductId { get; set; } // Klucz obcy dla Product
    public virtual Product Product { get; set; }
    public int Quantity { get; set; }
}
