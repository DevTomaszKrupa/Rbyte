using Microsoft.EntityFrameworkCore;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Discount;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rbyte.Application.Discount
{
    public interface IDiscountService
    {
        Task CreateAsync(DiscountDto model);
        Task<DiscountDto> GetAsync(int discountId);
        Task<List<DiscountDto>> GetAsync();
        Task UpdateAsync(DiscountDto model);
        Task DeleteAsync(int discountId);
    }

    public class DiscountService : IDiscountService
    {
        private readonly RbyteContext _context;
        public DiscountService(RbyteContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(DiscountDto model)
        {
            var dbDiscount = new DbDiscount
            {
                Value = model.Value
            };
            await _context.Discounts.AddAsync(dbDiscount);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int discountId)
        {
            var dbDiscount = await _context.Discounts.FirstAsync(x => x.DiscountId == discountId);
            _context.Discounts.Remove(dbDiscount);
        }

        public async Task<DiscountDto> GetAsync(int discountId)
        {
            var discount = await _context.Discounts
                .Where(x => x.DiscountId == discountId)
                .Select(x => new DiscountDto
                {
                    Value = x.Value,
                    DiscountId = x.DiscountId
                }).FirstAsync();
            return discount;
        }

        public async Task<List<DiscountDto>> GetAsync()
        {
            var list = await _context.Discounts.Select(x => new DiscountDto
            {
                DiscountId = x.DiscountId,
                Value = x.Value
            }).ToListAsync();
            return list;
        }

        public async Task UpdateAsync(DiscountDto model)
        {
            var dbDiscount = await _context.Discounts.FirstAsync(x => x.DiscountId == model.DiscountId);
            dbDiscount.Value = model.Value;
            await _context.SaveChangesAsync();
        }
    }
}