﻿using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace WebStore.Model;
public class OrderProduct
{
    public int ProductId { get; set; }
    public int OrderId { get; set; }
    public int Quantity { get; set; }
    public virtual Product Product { get; set; }
    public virtual Order Order { get; set; }
}
