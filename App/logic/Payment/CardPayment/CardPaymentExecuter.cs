using System;

namespace logic.Payment.CardPayment
{
    public interface ICardPaymentExecuter
    {
        void Execute();
    }

    public class CardPaymentExecuter : ICardPaymentExecuter
    {
        public void Execute()
        {
        }
    }
}