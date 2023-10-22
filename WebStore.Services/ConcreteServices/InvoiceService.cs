using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebStore.DAL.EF;
using WebStore.Model;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
namespace WebStore.Services.ConcreteServices
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        public InvoiceService(ApplicationDbContext dbContext, IMapper mapper, ILogger logger) : base(dbContext, mapper, logger)
        {
        }

        public InvoiceVm AddOrUpdateInvoice(AddOrUpdateInvoiceVm AddOrUpdateInvoiceVm)
        {
                        try
            {
                if (AddOrUpdateInvoiceVm == null)
                    throw new ArgumentNullException("View model parameter is null");
                var invoiceEntity = Mapper.Map<Invoice>(AddOrUpdateInvoiceVm);
                if (AddOrUpdateInvoiceVm.Id.HasValue || AddOrUpdateInvoiceVm.Id == 0)
                    DbContext.Invoice.Update(invoiceEntity);
                else
                    DbContext.Invoice.Add(invoiceEntity);
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
                    throw new ArgumentNullException("Filter expression parameter is null");
                var invoiceEntity = DbContext.Invoice.FirstOrDefault(filterExpression);
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
                var invoicesQuery = DbContext.Invoice.AsQueryable();
                if (filterExpression != null)
                    invoicesQuery = invoicesQuery.Where(filterExpression);
                var invoiceVms = Mapper.Map<IEnumerable<InvoiceVm>>(invoicesQuery);
                return invoiceVms;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}