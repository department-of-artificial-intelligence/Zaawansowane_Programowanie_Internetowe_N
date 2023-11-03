using Microsoft.EntityFrameworkCore;
using WebStore.DAL.EF;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTests;
public class InvoiceServiceUnitTests : BaseUnitTests
{
    private readonly IInvoiceService _service;
    private readonly ApplicationDbContext _context;
    public InvoiceServiceUnitTests(ApplicationDbContext dbContext,
        IInvoiceService InvoiceService) : base(dbContext)
    {
        _service = InvoiceService;
        _context = dbContext;
    }

    [Fact]
    public void GetInvoiceTest()
    {
        var invoice = _service.GetInvoice(p => p.TotalPrice == 2222);
        Assert.NotNull(invoice);
    }

    [Fact]
    public void GetMultipleInvoicesTest()
    {
        var invoices = _service.GetInvoices(p => p.Id >= 1 && p.Id <= 2);
        Assert.NotNull(invoices);
        Assert.NotEmpty(invoices);
        Assert.Equal(2, invoices.Count());
    }

    [Fact]
    public void GetAllInvoicesTest()
    {
        var invoices = _service.GetInvoices();
        Assert.NotNull(invoices);
        Assert.NotEmpty(invoices);
        Assert.Equal(invoices.Count(), invoices.Count());
    }

    [Fact]
    public void AddNewInvoiceTest()
    {
        var newInvoiceVm = new AddOrUpdateInvoiceVm()
        {
            TotalPrice = 200,
            Date = new DateTime(2010, 12, 11),
            StationaryStoreId = 1,
        };
        var createdInvoice = _service.AddOrUpdateInvoice(newInvoiceVm);
        Assert.NotNull(createdInvoice);
        Assert.Equal(200, newInvoiceVm.TotalPrice);
    }

    [Fact]
    public void UpdateInvoiceTest()
    {
        var updateInvoiceVm = new AddOrUpdateInvoiceVm()
        {
            Id = 1,
            TotalPrice = 200,
            Date = new DateTime(2013, 10, 5),
            StationaryStoreId = 1,
        };
        var editedInvoiceVm = _service.AddOrUpdateInvoice(updateInvoiceVm);
        Assert.NotNull(editedInvoiceVm);
        Assert.Equal(new DateTime(2013, 10, 5), editedInvoiceVm.Date);
        Assert.Equal(200, editedInvoiceVm.TotalPrice);
    }

    [Fact]
    public async Task DeleteInvoiceTest()
    {
        int invoiceId = 3;

        bool doesInvoiceExistsBefore = await _context.Invoice.AnyAsync(x => x.Id == invoiceId);
        await _service.DeleteInvoice(x => x.Id == invoiceId);
        bool doesInvoiceExistsAfter = await _context.Invoice.AnyAsync(x => x.Id == invoiceId);

        Assert.True(doesInvoiceExistsBefore);
        Assert.False(doesInvoiceExistsAfter);
    }
}