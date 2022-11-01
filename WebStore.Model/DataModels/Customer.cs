using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebStore.Model.DataModels;

public class Customer : User {

    public virtual IList<Order> Orders { get; set; } = default !;
    public virtual IList<Address> Addresses { get; set; } = default !;

    public virtual Address? BillingAddress { get; set; }

    [ForeignKey ("BillingAddress")]
    public int? BillingAddressId { get; set; }

    public virtual Address ShippingAddress { get; set; } = default !;

    [ForeignKey ("ShippingAddress")]
    public int ShippingAddressId { get; set; }

}