using logic.Payment;
using Shouldly;
using Xunit;

namespace test.Payment
{
    public class PaymentMethodProviderTests
    {
        private PaymentMethodProvider Sut { get; }

        public PaymentMethodProviderTests()
        {
            Sut = new PaymentMethodProvider();
        }

        [Fact]
        public void GivenCostOver1000_ThenReturnsCardPaymentMethod()
        {
            // Arrange
            const decimal cost = 2500m;

            // Act
            var result = Sut.Get(cost);

            // Assert
            result.ShouldBe(PaymentMethod.Card);
        }

        [Fact]
        public void GivenCostUnder1000_ThenReturnsCashPaymentMethod()
        {
            // Arrange
            const decimal cost = 25m;

            // Act
            var result = Sut.Get(cost);

            // Assert
            result.ShouldBe(PaymentMethod.Cash);
        }

        [Fact]
        public void GivenCostEqual0_ThenReturnsCashPaymentMethod()
        {
            // Arrange
            const decimal cost = 0;

            // Act
            var result = Sut.Get(cost);

            // Assert
            result.ShouldBe(PaymentMethod.Cash);
        }

        [Fact]
        public void GivenCostUnder0_ThenReturnsCashPaymentMethod()
        {

            // Arrange
            const decimal cost = -100m;

            // Act
            var result = Sut.Get(cost);

            // Assert
            result.ShouldBe(PaymentMethod.Cash);
        }
    }
}