
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
using WebStore.Model;
using WebStore.Services.ConcreteServices;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

public class InvoiceSevice : BaseService, IInvoiceService
{
    public InvoiceSevice(ApplicationDbContext dbContext, IMapper mapper, ILogger logger)
        : base(dbContext, mapper, logger)
    {

    }
    public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression)
    {

        try
        {
            if (filterExpression == null)
                throw new ArgumentNullException("Filter expression parameter is null");
            var invoiceEntity = DbContext.Invoices.FirstOrDefault(filterExpression);
            var invoiceVm = Mapper.Map<InvoiceVm>(invoiceEntity);
            return invoiceVm;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }

    public IEnumerable<InvoiceVm> GetInvoices(Expression<Func<Invoice, bool>>? filterExpression = null)
    {
        try
        {
            var invoices = DbContext.Invoices.ToList();
            var invoiceVms = Mapper.Map<IEnumerable<InvoiceVm>>(invoices);
            return invoiceVms;
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, ex.Message);
            throw;
        }
    }
}
