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

                //Act
                await sut.CreateAsync(apiDiscount);

                //Assert
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
                var sut = new DiscountService(context);
                var d1 = new DbDiscount { DiscountId = 0, Value = 10 };
                var d2 = new DbDiscount { DiscountId = 1, Value = 20 };
                var d3 = new DbDiscount { DiscountId = 2, Value = 30 };
                await context.Discounts.AddAsync(d1);
                await context.Discounts.AddAsync(d2);
                await context.Discounts.AddAsync(d3);
                await context.SaveChangesAsync();

                //Act
                var list = await sut.GetAsync();

                //Assert
                var listArr = list.ToArray();
                listArr[0].Value.ShouldBe(10);
                listArr[0].DiscountId.ShouldBe(0);
                listArr[1].Value.ShouldBe(20);
                listArr[1].DiscountId.ShouldBe(1);
                listArr[2].Value.ShouldBe(30);
                listArr[2].DiscountId.ShouldBe(2);
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

                //Act
                var list =await sut.GetAsync();

                //Assert
                list.ToArray().Length.ShouldBe(0);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void GetById_ListofItems_ReturnsSelectedItem()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                var sut = new DiscountService(context);
                var d1 = new DbDiscount { DiscountId = 0, Value = 10 };
                var d2 = new DbDiscount { DiscountId = 1, Value = 20 };
                var d3 = new DbDiscount { DiscountId = 2, Value = 30 };
                await context.Discounts.AddAsync(d1);
                await context.Discounts.AddAsync(d2);
                await context.Discounts.AddAsync(d3);
                await context.SaveChangesAsync();

                //Act
                var item = await sut.GetAsync(1);

                //Assert
                item.DiscountId.ShouldBe(1);
                item.Value.ShouldBe(20);
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void GetById_EmptyList_ThrowsException()
        {
            void  Method(RbyteContext context)
            {
                //Arrange
                var sut = new DiscountService(context);

                //Act
                Func<Task> f=async () =>  await sut.GetAsync(3);

                //Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void Delete_ExistingDiscount_DeletesDiscount()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                var sut = new DiscountService(context);
                var d1 = new DbDiscount { DiscountId = 0, Value = 10 };
                await context.AddAsync(d1);
                await context.SaveChangesAsync();

                //Act
                await sut.DeleteAsync(1);

                //Assert
                context.Discounts.Any(x => x.DiscountId == 1).ShouldBe(false); 
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }

        [Fact]
        public void Delete_NotExistingDiscount_DeletesDiscount()
        {
            void Method(RbyteContext context)
            {
                //Arrange
                var sut = new DiscountService(context);

                //Act
                Func<Task> f = async () => await sut.DeleteAsync(3);

                //Assert
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.Invoke(Method);
        }

        [Fact]
        public void Update_ListWithUpdatingItem_UpdatesItem()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                var sut = new DiscountService(context);
                var d1 = new DbDiscount { DiscountId = 0, Value = 10 };
                var d2 = new DbDiscount { DiscountId = 1, Value = 20 };
                var d3 = new DbDiscount { DiscountId = 2, Value = 30 };
                var d2forUpdate = new DiscountDto { DiscountId=2, Value = 20 };
                await context.Discounts.AddAsync(d1);
                await context.Discounts.AddAsync(d2);
                await context.Discounts.AddAsync(d3);
                await context.SaveChangesAsync();

                //Act
                await sut.UpdateAsync(d2forUpdate);

                //Act
                var updatedItem = context.Discounts.First(x => x.DiscountId == 2);
                updatedItem.Value.ShouldBe(20);
            }

            RbyteContextActionInvoker.InvokeAsync(Method);
        }
        [Fact]
        public void Update_WithoutUpdatingItem_ThrowsException()
        {
            async Task Method(RbyteContext context)
            {
                //Arrange
                var sut = new DiscountService(context);
                var ItemforUpdate = new DiscountDto { DiscountId = 2, Value = 20 };

                //Act
                Func<Task> f = async () => await sut.UpdateAsync(ItemforUpdate);

                //Act
                f.ShouldThrow<Exception>();
            }
            RbyteContextActionInvoker.InvokeAsync(Method);
        }
    }
}
