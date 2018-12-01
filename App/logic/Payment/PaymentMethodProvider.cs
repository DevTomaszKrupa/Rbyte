namespace logic.Payment
{
    public interface IPaymentMethodProvider
    {
        PaymentMethod Get(decimal cost);
    }

    public class PaymentMethodProvider : IPaymentMethodProvider
    {
        public PaymentMethod Get(decimal cost)
        {
            return cost < 1000 ? PaymentMethod.Cash : PaymentMethod.Card;
        }
    }

    public enum PaymentMethod
    {
        Card = 1,
        Cash,
    }
}