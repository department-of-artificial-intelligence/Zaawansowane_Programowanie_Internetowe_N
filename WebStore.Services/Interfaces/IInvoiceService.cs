using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.VM;
using WebStore.Services.ConcreteServices;
namespace WebStore.Services.Interfaces
{
    public interface IInvoiceService
    {
        InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression);
        IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>>? filterExpression = null);
    }
}
