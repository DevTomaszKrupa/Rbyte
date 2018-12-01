using System;

namespace logic.Payment.CashPayment
{
    public interface ICashPaymentExecuter
    {
        void Execute();
    }

    public class CashPaymentExecuter : ICashPaymentExecuter
    {
        public void Execute()
        {
        }
    }
}