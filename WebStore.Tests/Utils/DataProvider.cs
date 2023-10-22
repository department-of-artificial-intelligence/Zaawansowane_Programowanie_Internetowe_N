using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Model.Entities;

namespace WebStore.Tests.Utils
{
    public static class DataProvider
    {
        #region methods
        public static IList<Invoice>  PrepareInvoices()
         => new List<Invoice>(){
             new Invoice(){
            Id = 1,
            DeliveryDate = new DateTime(2023,10,21),
            OrderDate = new DateTime(2023, 10, 25),
        },
        new Invoice(){
            Id = 2,
            DeliveryDate = new DateTime(2023,10,25),
            OrderDate = new DateTime(2023, 10, 28),
        },

        };
    public static IList<Address> PrepareAddresses()
        => new List<Address>(){
            new Address(){
                Id = 1,
                BillingAddress = "42480 Emilie Run, Goldnerfort, HI 03739-8988",
                ShippingAddress = "639 Shalanda Shore, Mosciskiton, NH 89850-6735"
                
            },
            new Address(){
                Id = 2,
                BillingAddress = "Apt. 903 66109 Glennis Meadows, South Lalaborough, OR 98513-2566",
                ShippingAddress = "Suite 293 164 Conroy Causeway, Hirthetown, WV 78211-4150",
                CustomerId = 3
            }
        };

    public static IList<Order> PrepareOrders()
        =>new List<Order>{
            new Order(){
                Id = 1,
                DeliveryDate = new DateTime(2023,10,25),
                OrderDate = new DateTime(2023,10,27),
                TotalAmount = 2050.0m,
                TrackingNumber = 10
            },
            new Order(){
                Id = 2,
                DeliveryDate = new DateTime(2023,10,27),
                OrderDate = new DateTime(2023,10,28),
                TotalAmount = 27.5m,
                TrackingNumber = 15
            }
        };
    public static IList<StationaryStore> PrepareStationaryStores()
        => new List<StationaryStore>(){
                new StationaryStore(){

                }
        };


    public static IList<Customer> PrepareCustomers()
        => new List<Customer>(){
            new Customer(){
                Id= 3,
                FirstName = "Jan",
                LastName = "Kowalski",
            },
            new Customer(){
                Id= 4,
                FirstName = "Andrzej",
                LastName = "Nowak",
            }
        };


        #endregion
    }
}