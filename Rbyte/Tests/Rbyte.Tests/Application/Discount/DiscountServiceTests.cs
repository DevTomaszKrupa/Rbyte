using Rbyte.Api.Models.Discount;
using Rbyte.Application.Discount;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                var apiDiscount = new ApiDiscount
                {
                    Value = 7
                };

                //Act
                discountService.Create(apiDiscount);

                //Assert
                var discounts = context.Discounts.ToArray();
                discounts.Length.ShouldBe(1);
                discounts[0].Value.ShouldBe(7);
            }
            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
