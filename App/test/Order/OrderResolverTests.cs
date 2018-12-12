using logic;
using logic.Order;
using logic.Order.OrderPrice;
using logic.Payment;
using logic.Payment.Policy;
using logic.User;
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
        private IUserAuthorizer UserAuthorizer;
        private IPaymentPolicyService PaymentPolicyService;
        private List<ProductDto> ProductList { get; }
        private UserDto AdultUser { get; }
        private OrderResolver Sut { get; }

        public OrderResolverTests()
        {
            OrderPriceCalculator = Substitute.For<IOrderPriceCalculator>();
            PaymentMethodProvider = Substitute.For<IPaymentMethodProvider>();
            UserAuthorizer = Substitute.For<IUserAuthorizer>();
            PaymentPolicyService = Substitute.For<IPaymentPolicyService>();
            ProductList = new List<ProductDto> {
                new ProductDto
                {
                    Discount = 10,
                    Name ="",
                    Price = 240m,
                    ProductId = 1
                }
            };
            AdultUser = new UserDto
            {
                Age = 20,
                Name = "asdas",
                UserId = 200
            };
            Sut = new OrderResolver(OrderPriceCalculator, PaymentMethodProvider, UserAuthorizer, PaymentPolicyService);
        }

        [Fact]
        public void GivenAgeUnder18_ThenItThrowsException()
        {
            // Arrange
            var user = new UserDto
            {
                Age = 11,
                Name = "asdas",
                UserId = 200
            };

            // Act Assert
            Should.Throw<ArgumentException>(() => Sut.Resolve(ProductList, user))
                .Message.ShouldBe("You must be adult to order");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        [InlineData(100000)]
        public void GivenOrderPrice_ThenItChecksIfPaymentMethodProviderIsCalledWithProperArgument(decimal orderPrice)
        {
            // Arrange
            OrderPriceCalculator.Calculate(ProductList).Returns(orderPrice);

            // Act
            Sut.Resolve(ProductList, AdultUser);

            // Assert
            PaymentMethodProvider.Received(1).Get(orderPrice);
        }

        [Theory]
        [InlineData(PaymentMethod.Card)]
        [InlineData(PaymentMethod.Cash)]
        public void GivenPaymentMethod_ThenItAuthorizesUser(PaymentMethod paymentMethod)
        {
            // Arrange
            OrderPriceCalculator.Calculate(ProductList).Returns(100m);
            PaymentMethodProvider.Get(100m).Returns(paymentMethod);

            // Act
            Sut.Resolve(ProductList, AdultUser);

            // Assert
            PaymentPolicyService.Received(1).Apply(paymentMethod);
        }

        [Theory]
        [InlineData(100, 0)]
        [InlineData(20000, 1)]
        [InlineData(0, 0)]
        public void GivenAgeOver18AndOrderPrice_ThenCheckUserAuthorization(decimal orderPrice, int authorizeCalls)
        {
            // Arrange
            OrderPriceCalculator.Calculate(ProductList).Returns(orderPrice);

            // Act
            Sut.Resolve(ProductList, AdultUser);

            // Assert
            UserAuthorizer.Received(authorizeCalls).Authorize(AdultUser);
        }
    }
}
