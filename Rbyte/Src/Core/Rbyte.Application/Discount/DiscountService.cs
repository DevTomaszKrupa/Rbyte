using Rbyte.Api.Models.Discount;
using Rbyte.Persistance;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public void Delete(int discountId)
        {
            throw new System.NotImplementedException();
        }

        public ApiDiscount Get(int discountId)
        {
            throw new System.NotImplementedException();
        }

        public List<ApiDiscount> Get()
        {
            throw new System.NotImplementedException();
        }

        public void Update(ApiDiscount model)
        {
            throw new System.NotImplementedException();
        }
    }
}