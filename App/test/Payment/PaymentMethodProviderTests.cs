using logic.Payment;
using Shouldly;
using Xunit;

namespace test.Payment
{
    public class WhenProvidingPaymentMethod
    {
        private PaymentMethodProvider Sut { get; }

        public WhenProvidingPaymentMethod()
        {
            Sut = new PaymentMethodProvider();
        }

        [Fact]
        public void GivenCostOver1000_ThenReturnsCardPaymentMethod()
        {
            // Assert
            const decimal cost = 2500m;

            // Act
            var result = Sut.Get(cost);

            // Arrange
            result.ShouldBe(PaymentMethod.Card);
        }

        [Fact]
        public void GivenCostUnder1000_ThenReturnsCashPaymentMethod()
        {
            // Assert
            const decimal cost = 25m;

            // Act
            var result = Sut.Get(cost);

            // Arrange
            result.ShouldBe(PaymentMethod.Cash);
        }

        [Fact]
        public void GivenCostEqual0_ThenReturnsCashPaymentMethod()
        {
            // Assert
            const decimal cost = 0;

            // Act
            var result = Sut.Get(cost);

            // Arrange
            result.ShouldBe(PaymentMethod.Cash);
        }

        [Fact]
        public void GivenCostUnder0_ThenReturnsCashPaymentMethod()
        {

            // Assert
            const decimal cost = -100m;

            // Act
            var result = Sut.Get(cost);

            // Arrange
            result.ShouldBe(PaymentMethod.Cash);
        }
    }
}