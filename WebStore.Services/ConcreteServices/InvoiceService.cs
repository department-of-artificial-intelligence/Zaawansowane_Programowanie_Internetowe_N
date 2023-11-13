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

        public async Task<bool> DeleteInvoiceByIdAsync(int? id){
            try{
                if(id.GetValueOrDefault() == 0)
                    return false;

                var extractedEntity = await _dbContext.Invoices.FirstOrDefaultAsync(_ => _.Id == id);
                if(extractedEntity is null)
                    return false;
                _dbContext.Invoices.Remove(extractedEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex){
                _logger.LogError(ex,$"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<(bool IsSuccess, InvoiceVm InvoiceVm)> CreateOrUpdateInvoiceAsync(InvoiceVm? invoiceVm)
        {
            try{
                if(invoiceVm is null)
                    return (false,null);
                var preparedEntity = _mapper.Map<Invoice>(invoiceVm);
                if(preparedEntity is null)
                    return (false,null);
                if(preparedEntity.Id >= 0){
                    _dbContext.Invoices.Update(preparedEntity);
                    await _dbContext.SaveChangesAsync();
                    return(true, invoiceVm);
                }
                else{
                    await _dbContext.Invoices.AddAsync(preparedEntity);
                    await _dbContext.SaveChangesAsync();
                    return (true,invoiceVm);
                }
                
            }
            catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }

        public async Task<bool> DeleteInvoiceAsync(Expression<Func<Invoice, bool>> expression)
        {
            try{
                if(expression is null)
                    return false;
                var extractedEntity = await _dbContext.Invoices.FirstOrDefaultAsync(expression);
                if(extractedEntity is null)
                    return false;
                _dbContext.Invoices.Remove(extractedEntity);
                await _dbContext.SaveChangesAsync();
                return true;
            }catch(Exception ex){
                _logger.LogError(ex, $"Exception message = {ex.Message}{System.Environment.NewLine} Exception StackTrace = {ex.StackTrace}{System.Environment.NewLine}");
                throw;
            }
        }
    }
}