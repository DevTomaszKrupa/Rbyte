using logic.Order.OrderPrice;
using logic.Payment;
using logic.Payment.Policy;
using logic.User;
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
        private readonly IUserAuthorizer _userAuthorizer;
        private readonly IPaymentPolicyService _paymentPolicyService;

        public OrderResolver(IOrderPriceCalculator orderPriceCalculator,
                             IPaymentMethodProvider paymentMethodProvider,
                             IUserAuthorizer userAuthorizer,
                             IPaymentPolicyService paymentPolicyService)
        {
            _orderPriceCalculator = orderPriceCalculator;
            _paymentMethodProvider = paymentMethodProvider;
            _userAuthorizer = userAuthorizer;
            _paymentPolicyService = paymentPolicyService;
        }

        public void Resolve(List<ProductDto> products, UserDto user)
        {
            if (user.Age < 18)
                throw new ArgumentException("You must be adult to order");

            var orderPrice = _orderPriceCalculator.Calculate(products);
            var paymentMethod = _paymentMethodProvider.Get(orderPrice);

            _paymentPolicyService.Apply(paymentMethod);

            if (orderPrice > 10000)
            {
                _userAuthorizer.Authorize(user);
            }
        }
    }
}