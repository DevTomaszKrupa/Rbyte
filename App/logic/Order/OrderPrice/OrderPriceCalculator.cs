﻿using System;
using System.Collections.Generic;

namespace logic.Order.OrderPrice
{
    public interface IOrderPriceCalculator
    {
        decimal Calculate(List<ProductDto> products);
    }

    public class OrderPriceCalculator : IOrderPriceCalculator
    {

        public decimal Calculate(List<ProductDto> products)
        {
            decimal sum = 0m;
            foreach (var item in products)
            {
                if (item.Discount > 100)
                    throw new Exception("Invalid discount value");

                sum += item.Discount == 0 ? item.Price : item.Price * item.Discount;
            }
            return sum;
        }
    }
}