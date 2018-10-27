using System;
using System.Collections.Generic;
using Rbyte.App.Models;

namespace Rbyte.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop
            {
                ShopId = 1,
                Name = "Bakeroph",
                Address = "Warsaw, Cicha 12/5"
            };

            Console.WriteLine($"Name before func call: {shop.Name}");
            ChangeShopInfo(shop);
            Console.WriteLine($"Name after func call: {shop.Name}");

            Console.WriteLine();

            int valueType = 10;
            Console.WriteLine($"Valuetype before func call: {valueType}");
            ChangeValueType(valueType);
            Console.WriteLine($"Valuetype after func call: {valueType}");

            Console.WriteLine();

            int valueType2 = 10;
            Console.WriteLine($"Valuetype before func with ref call: {valueType2}");
            ChangeValueTypeWithRef(ref valueType2);
            Console.WriteLine($"Valuetype after func with ref call: {valueType2}");


            Console.ReadLine();
        }

        public static void ChangeShopInfo(Shop shop)
        {
            shop.Name = "New name";
        }

        public static void ChangeValueType(int valueType)
        {
            valueType = 50;
        }

        public static void ChangeValueTypeWithRef(ref int valueType)
        {
            valueType = 50;
        }
    }
}
