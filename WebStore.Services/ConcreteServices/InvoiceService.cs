using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL;
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

        public async Task<(InvoiceVm invoice, bool isExtracted)?> GetInvoiceByIdAsync(Expression<Func<Invoice, bool>>? filterExpression = null)
        {
            try{
                if(filterExpression is null)
                    return (null, false);
                var rawResult = await DbContext.Invoices
                    .FirstOrDefaultAsync(filterExpression);
                if(rawResult is Invoice){
                    var invoiceVm = Mapper.Map<InvoiceVm>(rawResult);
                    return (invoiceVm, true);
                }
                else
                    return (null, false);


            }
            catch(Exception ex){
                Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<(IList<InvoiceVm> invoiceResults, bool isExtracted)?> GetInvoicesAsync(Expression<Func<Invoice, bool>>? filterExpression = null)
        {
            try{
                if(filterExpression is null)
                    return (null, false);
                var rawResults = await DbContext.Invoices
                    .Where(filterExpression)
                    .ToListAsync();
                if(rawResults.Count != 0 ){
                    var invoiceVmResults = Mapper.Map<IList<InvoiceVm>>(rawResults);
                    return (invoiceVmResults, true);
                }
                else
                    return (null, false);
                
            }
            catch(Exception ex){
                 Logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }


    }
}