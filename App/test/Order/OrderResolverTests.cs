using logic.Order;
using logic.Order.OrderPrice;
using logic.Payment;
using NSubstitute;
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
        public void GivenThen()
        {

        }
    }
}
