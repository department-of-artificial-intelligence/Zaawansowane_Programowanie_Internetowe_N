using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using System.Threading.Tasks; 
using WebStore.DAL.EF; 
using WebStore.Model.DataModels; 
using WebStore.Services.Interfaces; 
using WebStore.ViewModels.VM; 
using Xunit; 
namespace WebStore.Tests.UnitTests { 
    public class StoreServiceUnitTests : BaseUnitTests { 
        private readonly IStoreService _storeService; 
        public StoreServiceUnitTests (ApplicationDbContext dbContext, 
        IStoreService storeService) : base (dbContext) { 
            _storeService = storeService; 
        } 
        
        [Fact] 
        public void GetStoreTest () { 
            var store = _storeService.GetStore (s => s.ArrangementNumber == 2222); 
            Assert.NotNull (store); 
        } 
        
        [Fact] 
        public void GetMultipleStoresTest () { 
            var stores = _storeService.GetStores (s => s.Id >= 1 && s.Id <= 2); 
            Assert.NotNull (stores); 
            Assert.NotEmpty (stores); 
            Assert.Equal (2, stores.Count ()); 
        } 

        [Fact] 
        
        public void GetAllStoresTest () { 
            var stores = _storeService.GetStores (); 
            Assert.NotNull (stores); 
            Assert.NotEmpty (stores); 
            Assert.Equal (stores.Count (), stores.Count ()); 
        } 
        
        [Fact] 
        
        public void AddNewStoreTest () { 
            var newStoreVm = new AddOrUpdateStoreVm () { 
                
                ArrangementNumber = 1111
            }; 
                var createdStore = _storeService.AddOrUpdateStore (newStoreVm); 
                Assert.NotNull (createdStore); 
                Assert.Equal (1111, createdStore.ArrangementNumber); 
                
        }

        [Fact]

        public void UpdateStoreTest () { 
            var updateStoreVm = new AddOrUpdateStoreVm () { 
                
                ArrangementNumber = 1111
            }; 
            var editedStoreVm = _storeService.AddOrUpdateStore (updateStoreVm); 
            Assert.NotNull (editedStoreVm); 
            Assert.Equal (1111, editedStoreVm.ArrangementNumber); 
            
        } 
    }
}