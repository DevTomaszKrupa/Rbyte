using System.Collections.Generic;
using System.Linq;
using Rbyte.Application.Store.Create;
using Rbyte.Application.Store.Read;
using Rbyte.Application.Store.Update;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;

namespace Rbyte.Application.Store
{
    public interface IStoreService
    {
        void Create(CreateStoreModel model);
        ReadStoreModel Read(int storeId);
        IEnumerable<ReadStoreModel> Read();
        UpdateStoreModel GetForEdition(int storeId);
        void Update(UpdateStoreModel model);
        void Delete(int storeId);
    }
    public class StoreService : IStoreService
    {
        private readonly RbyteContext _context;
        public StoreService(RbyteContext context)
        {
            _context = context;
        }
        public void Create(CreateStoreModel model)
        {
            var dbStore = new DbStore
            {
                Name = model.Name
            };
            _context.Add(dbStore);
            _context.SaveChanges();
        }

        public void Delete(int storeId)
        {
            var dbStore = _context.Stores.Where(x => x.StoreId == storeId).First();
            _context.Stores.Remove(dbStore);
            _context.SaveChanges();
        }

        public UpdateStoreModel GetForEdition(int storeId)
        {
            var stores = _context.Stores
                                    .Where(x => x.StoreId == storeId)
                                    .Select(x => new UpdateStoreModel
                                    {
                                        StoreId = x.StoreId,
                                        Name = x.Name
                                    }).First();
            return stores;
        }

        public ReadStoreModel Read(int storeId)
        {
            var store = _context.Stores
                                    .Where(x => x.StoreId == storeId)
                                    .Select(x => new ReadStoreModel
                                    {
                                        StoreId = x.StoreId,
                                        Name = x.Name
                                    }).First();
            return store;
        }

        public IEnumerable<ReadStoreModel> Read()
        {
            var stores = _context.Stores.Select(x => new ReadStoreModel
            {
                StoreId = x.StoreId,
                Name = x.Name
            }).ToList();
            return stores;
        }

        public void Update(UpdateStoreModel model)
        {
            var dbStore = _context.Stores.Where(x => x.StoreId == model.StoreId).First();
            dbStore.Name = model.Name;
            if (model.ProductId.HasValue)
            {
                _context.StoreProducts.Add(new DbStoreProduct
                {
                    ProductId = model.ProductId.Value,
                    StoreId = dbStore.StoreId,
                    Count = model.Count
                });
            }
            _context.SaveChanges();
        }
    }
}