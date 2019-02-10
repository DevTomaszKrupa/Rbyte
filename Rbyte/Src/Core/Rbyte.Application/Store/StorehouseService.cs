using Microsoft.EntityFrameworkCore;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Storehouse;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbyte.Application.Store
{
    public interface IStorehouseService
    {
        Task CreateAsync(StorehouseDto model);
        Task<StorehouseDto> GetAsync(int storehouseId);
        Task<List<StorehouseDto>> GetAsync();
        Task UpdateAsync(StorehouseDto model);
        Task DeleteAsync(int storehouseId);
    }

    public class StorehouseService : IStorehouseService
    {
        private readonly RbyteContext _context;
        public StorehouseService(RbyteContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(StorehouseDto model)
        {
            var dbStore = new DbStore
            {
                Name = model.Name
            };
            await _context.Stores.AddAsync(dbStore);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int storehouseId)
        {
            var dbStore = await _context.Stores.FirstAsync(x => x.StoreId == storehouseId);
            _context.Stores.Remove(dbStore);
             await _context.SaveChangesAsync();
        }

        public Task<StorehouseDto> GetAsync(int storehouseId)
        {
            var store = _context.Stores.Where(x => x.StoreId == storehouseId).Select(x => new StorehouseDto
            {
                Name = x.Name
            }).FirstAsync();
            return store;
        }

        public Task<List<StorehouseDto>> GetAsync()
        {
            return _context.Stores.Select(x => new StorehouseDto
            {
                StorehouseId = x.StoreId,
                Name = x.Name
            }).ToListAsync();
        }

        public async Task UpdateAsync(StorehouseDto model)
        {
            var dbStore = await _context.Stores.FirstAsync(x => x.StoreId == model.StorehouseId);
            dbStore.Name = model.Name;
            await _context.SaveChangesAsync();
        }
    }
}