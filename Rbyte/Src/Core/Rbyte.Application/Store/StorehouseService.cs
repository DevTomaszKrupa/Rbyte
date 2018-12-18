using Rbyte.Api.Models.Store;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Store
{
    public interface IStorehouseService
    {
        void Create(ApiStorehouse model);
        ApiStorehouse Get(int storehouseId);
        List<ApiStorehouse> Get();
        void Update(ApiStorehouse model);
        void Delete(int storehouseId);
    }
    public class StorehouseService : IStorehouseService
    {
        private readonly RbyteContext _context;
        public StorehouseService(RbyteContext context)
        {
            _context = context;
        }

        public void Create(ApiStorehouse model)
        {
            var dbStore = new DbStore
            {
                Name = model.Name
            };
            _context.Stores.Add(dbStore);
            _context.SaveChanges();
        }

        public void Delete(int storehouseId)
        {
            var dbStore = _context.Stores.First(x => x.StoreId == storehouseId);
            _context.Stores.Remove(dbStore);
            _context.SaveChanges();
        }

        public ApiStorehouse Get(int storehouseId)
        {
            var store = _context.Stores.Where(x => x.StoreId == storehouseId).Select(x => new ApiStorehouse
            {
                Name = x.Name
            }).First();
            return store;
        }

        public List<ApiStorehouse> Get()
        {
            return _context.Stores.Select(x => new ApiStorehouse
            {
                StorehouseId = x.StoreId,
                Name = x.Name
            }).ToList();
        }

        public void Update(ApiStorehouse model)
        {
            var dbStore = _context.Stores.First(x => x.StoreId == model.StorehouseId);
            dbStore.Name = model.Name;
            _context.SaveChanges();
        }
    }
}