using Rbyte.Application.Product.Read;
using Rbyte.Application.Store.Add;
using Rbyte.Application.Store.Create;
using Rbyte.Application.Store.Details;
using Rbyte.Application.Store.Read;
using Rbyte.Application.Store.Update;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Store
{
    public interface IStoreService
    {
        void Create(CreateStoreModel model);
        DetailsStoreModel Read(int storeId);
        IEnumerable<ReadStoreModel> Read();
        UpdateStoreModel GetForEdition(int storeId);
        void Update(UpdateStoreModel model);
        void Delete(int storeId);
        void AddProduct(AddStoreProductModel model);
        AddStoreProductModel GetForAdd(int storeId);
    }
    public class StoreService : IStoreService
    {
        private readonly RbyteContext _context;
        public StoreService(RbyteContext context)
        {
            _context = context;
        }

        public void AddProduct(AddStoreProductModel model)
        {
            if (model.ProductId.HasValue)
            {
                _context.StoreProducts.Add(new DbStoreProduct
                {
                    ProductId = model.ProductId.Value,
                    StoreId = model.StoreId,
                    Count = model.Count
                });
            }
            _context.SaveChanges();
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

        public AddStoreProductModel GetForAdd(int storeId)
        {
            var store = _context.Stores
                                    .Where(x => x.StoreId == storeId)
                                    .Select(x => new AddStoreProductModel
                                    {
                                        StoreId = x.StoreId,
                                        Name = x.Name
                                    }).First();
            return store;
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

        public DetailsStoreModel Read(int storeId)
        {
            var store = _context.Stores
                                    .Where(x => x.StoreId == storeId)
                                    .Select(x => new DetailsStoreModel
                                    {
                                        StoreId = x.StoreId,
                                        Name = x.Name,
                                        Products = x.StoreProducts.Select(prod => new ReadProductModel
                                        {
                                            Barcode = prod.Product.Barcode,
                                            Description = prod.Product.Description,
                                            Name = prod.Product.Name,
                                            Price = $"{prod.Product.StandardPrice.ToString()} PLN",
                                            ProductId = prod.ProductId
                                        }).ToList()
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
            _context.SaveChanges();
        }
    }
}