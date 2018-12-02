using logic;
using logic.Order.OrderPrice;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace test.Order.OrderPrice
{
    public class OrderPriceCalculatorTests
    {
        private OrderPriceCalculator Sut { get; }

        public OrderPriceCalculatorTests()
        {
            Sut = new OrderPriceCalculator();
        }

        [Fact]
        public void GivenProductListWithDiscountOver100_ThenThrowsException()
        {
            // Arrange
            var list = GetCorrectProducts();
            list.Add(new ProductDto
            {
                Discount = 400,
                Name = "test",
                Price = 8.09m,
                ProductId = 102
            });

            // Act Assert
            Should.Throw<Exception>(() => Sut.Calculate(list)); // TODO handle Message
        }

        [Fact]
        public void GivenProductListWithAllDiscountsBetween1And100_ThenReturnsCorrectSum()
        {
            // Arrange
            var list = GetCorrectProducts();

            // Act
            var result = Sut.Calculate(list);

            // Assert
            result.ShouldBe(21.04m);
        }

        [Fact]
        public void GivenProductListWithDiscountEqual0_ThenReturnsCorrectSum()
        {
            // Arrange
            var list = GetCorrectProducts();
            list.Add(new ProductDto
            {
                Discount = 0,
                Name = "test",
                Price = 4.0m,
                ProductId = 90
            });

            // Act
            var result = Sut.Calculate(list);

            // Assert
            result.ShouldBe(25.04m);
        }

        [Fact]
        public void GivenEmptyList_ThenReturns0()
        {
            // Arrange
            var list = new List<ProductDto>();

            // Act
            var result = Sut.Calculate(list);

            // Assert
            result.ShouldBe(0);
        }

        private List<ProductDto> GetCorrectProducts()
        {
            return new List<ProductDto>
            {
                new ProductDto
                {
                    Discount = 30,
                    Name = "fake_name",
                    Price = 10m,
                    ProductId = 12
                },
                new ProductDto
                {
                    Discount = 10,
                    Name = "another_fake_name",
                    Price = 15.6m,
                    ProductId = 5
                },
                new ProductDto
                {
                    Discount = 5,
                    Name = "fake",
                    Price = 0,
                    ProductId = 1
                }
            };
        }
    }
}
