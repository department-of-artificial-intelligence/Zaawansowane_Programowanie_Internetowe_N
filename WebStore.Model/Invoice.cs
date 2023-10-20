
namespace WebStore.Model;

public class Invoice{
    public int Id {get;set;}
    public int InvoiceNumber {get;set;}
    public IList<Order> Orders {get;set;}
}
//INSERT [dbo].[Invoices] ([InvoiceNumber], [OrderId]) VALUES (N'123/331', 1)
