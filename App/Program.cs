using System;
using System.Collections.Generic;
using Rbyte.App.Models;

namespace Rbyte.App
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            // not allowed operation
            // number = null;

            int? nullableNumber = 1;
            nullableNumber = null;

            DisplayNullableNumberValue(nullableNumber);
            DisplayNullableNumberValue(number);
            DisplayNullableNumberValue(20);
            DisplayNullableNumberValue(null);
            DisplayProduct(new Product("Bread", "Gluten free", (decimal)2.99, "GryphT"));
            DisplayProduct(null);

            Console.ReadLine();
        }

        public static void DisplayNullableNumberValue(int? number)
        {
            if (!number.HasValue)
            {
                Console.WriteLine("Number doesnt have value!");
            }
            else
            {
                Console.WriteLine($"Number has value: {number.Value}");
            }
        }
        public static void DisplayProduct(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Product is null!");
            }
            else
            {
                Console.WriteLine("Product has value");
            }
        }
    }
}
