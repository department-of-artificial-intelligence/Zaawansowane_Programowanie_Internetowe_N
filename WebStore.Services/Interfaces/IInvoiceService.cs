using System.Linq.Expressions;
using WebStore.Model;
using WebStore.ViewModels.VM;

namespace WebStore.Services.Interfaces;
public interface IInvoiceService
{
    public InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm);
    public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression);
    public IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>>? filterExpression = null);
    public Task DeleteInvoice(Expression<Func<Invoice, bool>> filterExpression);
}