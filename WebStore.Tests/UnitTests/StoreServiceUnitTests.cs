using Microsoft.EntityFrameworkCore;
using WebStore.DAL.EF;
using WebStore.Services.Interfaces;
using WebStore.ViewModels.VM;
using Xunit;

namespace WebStore.Tests.UnitTests;
public class StoreServiceUnitTests : BaseUnitTests
{
    private readonly IStoreService _storeService;
    private readonly ApplicationDbContext _dbContext;
    public StoreServiceUnitTests(ApplicationDbContext dbContext,
        IStoreService storeService) : base(dbContext)
    {
        _storeService = storeService;
        _dbContext = dbContext;
    }

    [Fact]
    public void GetStationaryStoreTest()
    {
        var stationaryStore = _storeService.GetStationaryStore(p => p.Name == "Store2");
        Assert.NotNull(stationaryStore);
    }

    [Fact]
    public void GetMultipleStationaryStoresTest()
    {
        var stationaryStores = _storeService.GetStationaryStores(p => p.Id >= 1 && p.Id <= 2);
        Assert.NotNull(stationaryStores);
        Assert.NotEmpty(stationaryStores);
        Assert.Equal(2, stationaryStores.Count());
    }

    [Fact]
    public void GetAllStationaryStoresTest()
    {
        var stationaryStores = _storeService.GetStationaryStores();
        Assert.NotNull(stationaryStores);
        Assert.NotEmpty(stationaryStores);
        Assert.Equal(stationaryStores.Count(), stationaryStores.Count());
    }

    [Fact]
    public void AddNewStationaryStoreTest()
    {
        var newStationaryStoreVm = new AddOrUpdateStoreVm()
        {
            Name = "New Store",
        };

        var createdStationaryStore = _storeService.AddOrUpdateStore(newStationaryStoreVm);
        Assert.NotNull(createdStationaryStore);
        Assert.Equal("New Store", createdStationaryStore.Name);
    }

    [Fact]
    public void UpdateStationaryStoreTest()
    {
        var updateStationaryStoreVm = new AddOrUpdateStoreVm()
        {
            Id = 1,
            Name = "new name"
        };
        var editedStationaryStoreVm = _storeService.AddOrUpdateStore(updateStationaryStoreVm);
        Assert.NotNull(editedStationaryStoreVm);
        Assert.Equal("new name", editedStationaryStoreVm.Name);
    }

    [Fact]
    public async Task DeleteStationaryStoreTest()
    {
        int stationaryStoreId = 3;

        bool doesStationaryStoreExistsBefore = await _dbContext.StationaryStore.AnyAsync(x => x.Id == stationaryStoreId);
        await _storeService.DeleteStationaryStore(x => x.Id == stationaryStoreId);
        bool doesStationaryStoreExistsAfter = await _dbContext.StationaryStore.AnyAsync(x => x.Id == stationaryStoreId);

        Assert.True(doesStationaryStoreExistsBefore);
        Assert.False(doesStationaryStoreExistsAfter);
    }
}