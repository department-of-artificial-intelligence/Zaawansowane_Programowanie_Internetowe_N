using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebStore.DAL.Persistence;
using WebStore.Model.Entities;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.ViewModels;

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
                var rawResult = await _dbContext.Invoices
                    .FirstOrDefaultAsync(filterExpression);
                if(rawResult is Invoice){
                    var invoiceVm = _mapper.Map<InvoiceVm>(rawResult);
                    return (invoiceVm, true);
                }
                else
                    return (null, false);


            }
            catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<(IList<InvoiceVm> invoiceResults, bool isExtracted)?> GetInvoicesAsync(Expression<Func<Invoice, bool>>? filterExpression = null)
        {
            try{
                if(filterExpression is null)
                    return (null, false);
                var rawResults = await _dbContext.Invoices
                    .Where(filterExpression)
                    .ToListAsync();
                if(rawResults.Count != 0 ){
                    var invoiceVmResults = _mapper.Map<IList<InvoiceVm>>(rawResults);
                    return (invoiceVmResults, true);
                }
                else
                    return (null, false);
                
            }
            catch(Exception ex){
                 _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }


    }
}