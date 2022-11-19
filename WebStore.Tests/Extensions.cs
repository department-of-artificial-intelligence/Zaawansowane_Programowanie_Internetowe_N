using System;
using Microsoft.AspNetCore.Identity; 
using Microsoft.Extensions.DependencyInjection; 
using WebStore.DAL.EF; 
using WebStore.Model.DataModels; 
using WebStore.Services.Configuration;
namespace WebStore.Tests { 
    public static class Extensions {
        // Create sample data 
        public static async void SeedData (this IServiceCollection services) { 
            var serviceProvider = services.BuildServiceProvider (); 
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext> (); 
            var userManager = serviceProvider.GetRequiredService<UserManager<User>> (); 
            var roleManager = serviceProvider 
                .GetRequiredService<RoleManager<IdentityRole<int>>> (); 
                
            // other seed data ... 
            
            //Suppliers 
            var supplier1 = new Supplier () { 
                Id = 1, 
                FirstName = "Adam", 
                LastName = "Bednarski", 
                UserName = "supp1@eg.eg", 
                Email = "supp1@eg.eg", 
                RegistrationDate = new DateTime (2010, 1, 1), 
            }; 
            await userManager.CreateAsync (supplier1, "User1234"); 
            
            //Categories 
            var category1 = new Category () { 
                Id = 1, Name = "Computers", 
                Tag = "#computer" }; 
                await dbContext.AddAsync (category1);

            //Products 
            var p1 = new Product () { 
                Id = 1, 
                CategoryId = category1.Id, 
                SupplierId = supplier1.Id, 
                Description = "Bardzo praktyczny monitor 32 cale", 
                ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x80 }, 
                Name = "Monitor Dell 32", 
                Price = 1000, 
                Weight = 20, 
            }; 
            await dbContext.AddAsync (p1); 
            
            var p2 = new Product () { 
                Id = 2, 
                CategoryId = category1.Id, 
                SupplierId = supplier1.Id, 
                Description = "Precyzyjna mysz do pracy", 
                ImageBytes = new byte[] { 0xff, 0xff, 0xff, 0x70 }, 
                Name = "Mysz Logitech", Price = 500, Weight = 0.5f, 
            }; 
            await dbContext.AddAsync (p2); 

             //Invoice
            var i1 = new Invoice()
            {
                
                invoiceID = 1,
                totalPrice = 10,
                invoiceDate = new DateTime()
            };
            await dbContext.AddAsync(i1);
            var i2 = new Invoice()
            {
                
                invoiceID = 2,
                totalPrice = 20,
                invoiceDate = new DateTime()
            };
            await dbContext.AddAsync(i2);

            //Address

            var a1 = new Address()
            {
                Id = 1,
                StreetName = "Nalkowskiej",
                StreetNumber = 12,
                City = "Wielun",
                PostCode = "98300"

            };
            await dbContext.AddAsync(a1);
            var a2 = new Address()
            {
                Id = 2,
                StreetName = "Orzeszkowej",
                StreetNumber = 14,
                City = "Czestochowa",
                PostCode = "93400"

            };
            await dbContext.AddAsync(a2);
            var a3 = new Address()
            {
                Id = 3,
                StreetName = "Poludniowa",
                StreetNumber = 23,
                City = "Pila",
                PostCode = "93600"

            };
            await dbContext.AddAsync(a3);

            //Order

            var o1 = new Order()
            {
                Id = 1,
                DeliveryDate = new DateTime(),
                OrderDate = new DateTime(),
                TotalAmount = 1987.89m,
                TrackingNumber = 876677,
                Invoiceid = 234,
                CustomerId = 1
            };
            await dbContext.AddAsync(o1);

            var o2 = new Order()
            {
                Id = 2,
                DeliveryDate = new DateTime(),
                OrderDate = new DateTime(),
                TotalAmount = 2111.89m,
                TrackingNumber = 34343,
                Invoiceid = 543,
                CustomerId = 3
            };
            await dbContext.AddAsync(o2);

            //Stores

            var s1 = new StationaryStore()
            {
                
                
                ArrangementNumber = 1111
                
                
            };
            await dbContext.AddAsync(s1);

            var s2 = new StationaryStore()
            {
                
                
                ArrangementNumber = 2222
            };
            await dbContext.AddAsync(s2);
            
            // save changes 
            
            await dbContext.SaveChangesAsync (); 
            } 
        } 
    }