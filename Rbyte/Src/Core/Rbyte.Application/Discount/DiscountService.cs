using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rbyte.Domain.Entities;
using Rbyte.Persistance;
using Rbyte.Application.Discount.Create;
using Rbyte.Application.Discount.Read;
using Rbyte.Application.Discount.Update;

namespace Rbyte.Application.Discount
{
    public interface IDiscountService
    {
        void Create(CreateDiscountModel model);
        ReadDiscountModel Read(int discountId);
        IEnumerable<ReadDiscountModel> Read();
        UpdateDiscountModel GetForEdition(int discountId);
        void Update(UpdateDiscountModel model);
        void Delete(int discountId);
    }
    public class DiscountService : IDiscountService
    {
        private readonly RbyteContext _context;
        public DiscountService(RbyteContext context)
        {
            _context = context;
        }
        public void Create(CreateDiscountModel model)
        {
            var dbDiscount = new DbDiscount
            {
                Value = model.Value
            };
            _context.Discounts.Add(dbDiscount);
            var productDiscounts = _context.CategoryProducts.Where(x => x.CategoryId == model.CategoryId)
                                                            .Select(x => new DbProductDiscount
                                                            {
                                                                ProductId = x.ProductId,
                                                                DiscountId = dbDiscount.DiscountId
                                                            }).ToList();
            _context.ProductDiscounts.AddRange(productDiscounts);
            _context.SaveChanges();
        }
        public ReadDiscountModel Read(int discountId)
        {
            var discount = _context.Discounts.Where(x => x.DiscountId == discountId)
                                             .Select(x => new ReadDiscountModel
                                             {
                                                 DiscountId = x.DiscountId,
                                                 Value = x.Value
                                             }).First();
            return discount;
        }

        public IEnumerable<ReadDiscountModel> Read()
        {
            var discounts = _context.Discounts.Select(x => new ReadDiscountModel
            {
                DiscountId = x.DiscountId,
                Value = x.Value
            }).ToList();
            return discounts;
        }

        public UpdateDiscountModel GetForEdition(int discountId)
        {
            var discount = _context.Discounts.Where(x => x.DiscountId == discountId)
                                             .Select(x => new UpdateDiscountModel
                                             {
                                                 DiscountId = x.DiscountId,
                                                 Value = x.Value
                                             }).First();
            return discount;
        }
        public void Update(UpdateDiscountModel model)
        {
            var dbDiscount = _context.Discounts.First(x => x.DiscountId == model.DiscountId);
            dbDiscount.Value = model.Value;
            _context.SaveChanges();

        }
        public void Delete(int discountId)
        {
            var dbDiscount = _context.Discounts.First(x => x.DiscountId == discountId);
            _context.Discounts.Remove(dbDiscount);
            _context.SaveChanges();
        }
    }
}