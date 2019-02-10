using Rbyte.Application.Discount;
using Rbyte.Domain.Models.Discount;
using Rbyte.Persistance;
using Shouldly;
using System.Linq;
using Xunit;

namespace Rbyte.Tests.Application.Discount
{
    public class DiscountServiceTests
    {
        [Fact]
        public void Create_OneDiscount()
        {
            void Method(RbyteContext context)
            {
                // Arrange 
                var discountService = new DiscountService(context);
                var apiDiscount = new DiscountDto
                {
                    Value = 7
                };

                //Act
                discountService.CreateAsync(apiDiscount);

                //Assert
                var discounts = context.Discounts.ToArray();
                discounts.Length.ShouldBe(1);
                discounts[0].Value.ShouldBe(7);
            }
            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
