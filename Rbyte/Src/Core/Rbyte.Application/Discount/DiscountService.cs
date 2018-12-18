using Rbyte.Api.Models.Discount;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using System.Collections.Generic;
using System.Linq;

namespace Rbyte.Application.Discount
{
    public interface IDiscountService
    {
        void Create(ApiDiscount model);
        ApiDiscount Get(int discountId);
        List<ApiDiscount> Get();
        void Update(ApiDiscount model);
        void Delete(int discountId);
    }
    public class DiscountService : IDiscountService
    {
        private readonly RbyteContext _context;
        public DiscountService(RbyteContext context)
        {
            _context = context;
        }

        public void Create(ApiDiscount model)
        {
            var dbDiscount = new DbDiscount
            {
                Value = model.Value
            };
            _context.Discounts.Add(dbDiscount);
        }

        public void Delete(int discountId)
        {
            var dbDiscount = _context.Discounts.First(x => x.DiscountId == discountId);
            _context.Discounts.Remove(dbDiscount);
        }

        public ApiDiscount Get(int discountId)
        {
            var dbDiscount = _context.Discounts.First(x => x.DiscountId == discountId);
            return new ApiDiscount
            {
                DiscountId = dbDiscount.DiscountId,
                Value = dbDiscount.Value
            };
        }

        public List<ApiDiscount> Get()
        {
            return _context.Discounts.Select(x => new ApiDiscount
            {
                DiscountId = x.DiscountId,
                Value = x.Value
            }).ToList();
        }

        public void Update(ApiDiscount model)
        {
            var dbDiscount = _context.Discounts.First(x => x.DiscountId == model.DiscountId);
            dbDiscount.Value = model.Value;
            _context.SaveChanges();
        }
    }
}