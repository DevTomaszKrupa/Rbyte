using logic;
using logic.Order;
using logic.Order.OrderPrice;
using logic.Payment;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace test.Order
{
    public class OrderResolverTests
    {
        private IOrderPriceCalculator OrderPriceCalculator { get; }
        private IPaymentMethodProvider PaymentMethodProvider { get; }
        private OrderResolver Sut { get; }

        public OrderResolverTests()
        {
            OrderPriceCalculator = Substitute.For<IOrderPriceCalculator>();
            PaymentMethodProvider = Substitute.For<IPaymentMethodProvider>();
            Sut = new OrderResolver(OrderPriceCalculator, PaymentMethodProvider);
        }

        [Fact]
        public void GivenAgeUnder18_ThenThrowException()
        {
            // Arrange
            var prodList = new List<ProductDto>();
            var user = new UserDto
            {
                Age = 11,
                Name = "asdas",
                UserId = 200
            };

            // Act Assert
            Should.Throw<ArgumentException>(() => Sut.Resolve(prodList, user))
                .Message.ShouldBe("You must be adult to order");
        }

        [Fact]
        public void GivenCorrectUser_WithCardPaymentMethod()
        {
            // Arrange
            var prodList = new List<ProductDto> {
                new ProductDto
                {
                    Discount = 10,
                    Name ="",
                    Price = 10m,
                    ProductId = 1
                }
            };
            var user = new UserDto
            {
                Age = 20,
                Name = "asdas",
                UserId = 200
            };
            OrderPriceCalculator.Calculate(prodList).Returns(100.8m);

            // Act
            Sut.Resolve(prodList, user);

            // Assert
            PaymentMethodProvider.Received(1).Get(100.0m);
        
        }


        [Fact]
        public void GivenCorrectUserAndCardPaymentMethod_ThenExecuteDoSmfWithCardPaymentMethod()
        {
            // Arrange
            var prodList = new List<ProductDto> {
                new ProductDto
                {
                    Discount = 10,
                    Name ="",
                    Price = 10m,
                    ProductId = 1
                }
            };
            var user = new UserDto
            {
                Age = 20,
                Name = "asdas",
                UserId = 200
            };

            // Act 

        }

    }
}
