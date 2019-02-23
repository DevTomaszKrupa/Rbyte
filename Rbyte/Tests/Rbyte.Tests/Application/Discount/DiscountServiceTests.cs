using Rbyte.Application.Discount;
using Rbyte.Domain.Entities;
using Rbyte.Domain.Models.Discount;
using Rbyte.Persistance;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Rbyte.Tests.Application.Discount
{
    public class DiscountServiceTests
    {
        [Fact]
        public void Create_OneDiscount()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange        
                var sut = new DiscountService(context);
                var apiDiscount = new DiscountDto
                {
                    Value = 7
                };

                // Act
                await sut.CreateAsync(apiDiscount);

                // Assert
                var discounts = context.Discounts.ToArray();
                discounts.Length.ShouldBe(1);
                discounts[0].Value.ShouldBe(7);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Get_ListOfItems_ReturnsListOfITems()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange     
                var d1 = new DbDiscount { DiscountId = 1, Value = 10 };
                var d2 = new DbDiscount { DiscountId = 2, Value = 20 };
                var d3 = new DbDiscount { DiscountId = 3, Value = 30 };
                context.Discounts.Add(d1);
                context.Discounts.Add(d2);
                context.Discounts.Add(d3);
                context.SaveChanges();
                var sut = new DiscountService(context);

                // Act
                var result = await sut.GetAsync();

                // Assert
                var resultArr = result.ToArray();
                resultArr.Length.ShouldBe(3);
                resultArr[0].Value.ShouldBe(10);
                resultArr[0].DiscountId.ShouldBe(1);
                resultArr[1].Value.ShouldBe(20);
                resultArr[1].DiscountId.ShouldBe(2);
                resultArr[2].Value.ShouldBe(30);
                resultArr[2].DiscountId.ShouldBe(3);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Get_EmptyList_ReturnsEmptyList()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var sut = new DiscountService(context);

                // Act
                var result = await sut.GetAsync();

                // Assert
                result.ToArray().Length.ShouldBe(0);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void GetById_ListofItems_ReturnsSelectedItem()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var d1 = new DbDiscount { DiscountId = 1, Value = 10 };
                var d2 = new DbDiscount { DiscountId = 2, Value = 20 };
                var d3 = new DbDiscount { DiscountId = 3, Value = 30 };
                context.Discounts.Add(d1);
                context.Discounts.Add(d2);
                context.Discounts.Add(d3);
                context.SaveChanges();
                var sut = new DiscountService(context);

                // Act
                var item = await sut.GetAsync(1);

                // Assert
                item.DiscountId.ShouldBe(2);
                item.Value.ShouldBe(20);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void GetById_EmptyList_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var sut = new DiscountService(context);

                // Act
                Func<Task> f = async () => await sut.GetAsync(3);

                // Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void Delete_ExistingDiscount_DeletesDiscount()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var d1 = new DbDiscount { DiscountId = 1, Value = 10 };
                context.Add(d1);
                context.SaveChanges();
                var sut = new DiscountService(context);

                // Act
                await sut.DeleteAsync(1);

                // Assert
                context.Discounts.Any(x => x.DiscountId == 1).ShouldBe(false);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_DiscountNotExist_DeletesDiscount()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var sut = new DiscountService(context);

                // Act
                Func<Task> f = async () => await sut.DeleteAsync(3);

                // Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void Update_ListWithUpdatingItem_UpdatesItem()
        {
            async Task Method(RbyteContext context)
            {
                // Arrange
                var d1 = new DbDiscount { DiscountId = 1, Value = 10 };
                var d2 = new DbDiscount { DiscountId = 2, Value = 20 };
                var d3 = new DbDiscount { DiscountId = 3, Value = 30 };
                context.Discounts.Add(d1);
                context.Discounts.Add(d2);
                context.Discounts.Add(d3);
                context.SaveChanges();
                var sut = new DiscountService(context);
                var d2forUpdate = new DiscountDto { DiscountId = 2, Value = 20 };

                // Act
                await sut.UpdateAsync(d2forUpdate);

                // Assert
                var updatedItem = context.Discounts.First(x => x.DiscountId == 2);
                updatedItem.Value.ShouldBe(20);
            }

            RbyteContextActionInvoker.InvokeAsync(Method);
        }
        [Fact]
        public void Update_WithoutUpdatingItem_ThrowsException()
        {
            void Method(RbyteContext context)
            {
                // Arrange
                var sut = new DiscountService(context);
                var ItemforUpdate = new DiscountDto { DiscountId = 2, Value = 20 };

                // Act
                Func<Task> f = async () => await sut.UpdateAsync(ItemforUpdate);

                // Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }
    }
}
