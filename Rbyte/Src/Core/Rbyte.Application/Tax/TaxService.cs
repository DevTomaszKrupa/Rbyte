using Microsoft.EntityFrameworkCore;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Tax;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbyte.Application.Tax
{
    public interface ITaxService
    {
        Task<int> CreateAsync(TaxDto model);
        Task<TaxDto> GetAsync(int taxId);
        Task<List<TaxDto>> GetAsync();
        Task UpdateAsync(TaxDto model);
        Task DeleteAsync(int taxId);
    }
    public class TaxService : ITaxService
    {
        private readonly RbyteContext _context;
        public TaxService(RbyteContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(TaxDto model)
        {
            var dbTax = new DbTax
            {
                Value = model.Value
            };
            await _context.Taxes.AddAsync(dbTax);
            await _context.SaveChangesAsync();
            return dbTax.TaxId;
        }

        public async Task DeleteAsync(int taxId)
        {
            var dbTax = await _context.Taxes.Where(x => x.TaxId == taxId).FirstAsync();
            _context.Taxes.Remove(dbTax);
            await _context.SaveChangesAsync();
        }

        public Task<TaxDto> GetAsync(int taxId)
        {
            var dbTax = _context.Taxes
                .Select(x => new TaxDto
                {
                    TaxId = x.TaxId,
                    Value = x.Value
                }).FirstAsync();
            return dbTax;
        }

        public Task<List<TaxDto>> GetAsync()
        {
            var list = _context.Taxes.Select(x => new TaxDto
            {
                TaxId = x.TaxId,
                Value = x.Value
            }).ToListAsync();
            return list;
        }

        public async Task UpdateAsync(TaxDto model)
        {
            var dbTax = await _context.Taxes.FirstAsync(x => x.TaxId == model.TaxId);
            dbTax.Value = model.Value;
            await _context.SaveChangesAsync();
        }
    }
}