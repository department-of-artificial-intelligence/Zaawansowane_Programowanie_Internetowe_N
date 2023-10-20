using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;

namespace WebStore.Services.ConcreteServices
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        public InvoiceService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) 
            : base(dbContext, mapper, logger) { }

        public InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm addOrUpdateInvoiceVm)
        {
            try
            {
                if (addOrUpdateInvoiceVm == null)
                {
                    throw new ArgumentNullException("View model parameter is null");
                }

                var invoiceEntity = Mapper.Map<Invoice>(addOrUpdateInvoiceVm);

                if (addOrUpdateInvoiceVm.Id.HasValue || addOrUpdateInvoiceVm.Id == 0)
                {
                    DbContext.Invoices.Update(invoiceEntity);
                }
                else
                {
                    DbContext.Invoices.Add(invoiceEntity);
                }

                DbContext.SaveChanges();

                var invoiceVm = Mapper.Map<InvoiceVm>(invoiceEntity);
                return invoiceVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public InvoiceVm GetInvoice(Expression<Func<Invoice, bool>> filterExpression)
        {
            try
            {
                if (filterExpression == null)
                {
                    throw new ArgumentNullException("Filter expression parameter is null");
                }

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
                var invoicesQuery = DbContext.Invoices.AsQueryable();

                if (filterExpression != null)
                {
                    invoicesQuery = invoicesQuery.Where(filterExpression);
                }

                var invoiceVms = Mapper.Map<IEnumerable<InvoiceVm>>(invoicesQuery);
                return invoiceVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public InvoiceVm CreateInvoiceFromOrder(int orderId)
        {
            try
            {
                var orderEntity = DbContext.Orders.Find(orderId);

                if (orderEntity == null)
                {
                    return null;
                }

                var invoiceEntity = new Invoice
                {
                    InvoiceNumber = GenerateInvoiceNumber(), 
                    Order = orderEntity
                };

                DbContext.Invoices.Add(invoiceEntity);
                DbContext.SaveChanges();

                var invoiceVm = Mapper.Map<InvoiceVm>(invoiceEntity);
                return invoiceVm;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }

        private string GenerateInvoiceNumber()
        {
            var currentDateTime = DateTime.Now;
            var randomPart = Guid.NewGuid().ToString().Substring(0, 6); // Losowy ciąg znaków

            var invoiceNumber = $"{currentDateTime:yyyyMMddHHmmss}-{randomPart}";

            return invoiceNumber;
        }
    }
}
