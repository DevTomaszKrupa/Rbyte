using System;

namespace logic.Payment.Policy
{
    public interface IPaymentPolicyService
    {
        void Apply(PaymentMethod payment);
    }

    public class PaymentPolicyService : IPaymentPolicyService
    {
        public void Apply(PaymentMethod payment)
        {
            Console.WriteLine(payment);
        }
    }
}
