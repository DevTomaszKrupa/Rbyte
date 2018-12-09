using logic.Order.OrderPrice;
using logic.Payment;
using System;
using System.Collections.Generic;

namespace logic.Order
{
    public interface IOrderResolver
    {
        void Resolve(List<ProductDto> products, UserDto user);
    }

    public class OrderResolver : IOrderResolver
    {
        private readonly IOrderPriceCalculator _orderPriceCalculator;
        private readonly IPaymentMethodProvider _paymentMethodProvider;

        public OrderResolver(IOrderPriceCalculator orderPriceCalculator,
                             IPaymentMethodProvider paymentMethodProvider)
        {
            _orderPriceCalculator = orderPriceCalculator;
            _paymentMethodProvider = paymentMethodProvider;
        }

        public void Resolve(List<ProductDto> products, UserDto user)
        {
            if (user.Age < 18)
                throw new ArgumentException("You must be adult to order");

            var orderPrice = _orderPriceCalculator.Calculate(products);
            var paymentMethod = _paymentMethodProvider.Get(orderPrice);
            DoSmf(paymentMethod);
            if (orderPrice > 100)
            {
                DoSmf2();
            }
        }

        private void DoSmf(PaymentMethod payment)
        {
            Console.WriteLine(payment);
        }
        private void DoSmf2()
        {

        }
        //GivenAgeUnder18_ThenThrowsException
        //GivenAgeOver18_Then
    }
}