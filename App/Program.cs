using System;

namespace Rbyte.App
{
    class Program
    {   // TODO: komentarze
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("This is my first .net core app!");

            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            Console.WriteLine("How old are you?");
            int age;
            var intParsingResult = int.TryParse(Console.ReadLine(), out age); // this is bool value
            if (!intParsingResult)
            {
                Console.WriteLine("You've entered the wrong value");
                Console.WriteLine("Program ended.");
                Console.ReadLine();
                return;
            }
            var youAreAdult = age >= 18;

            Console.WriteLine("How tall are you? [m]");
            decimal height;
            var decimalParsingResult = decimal.TryParse(Console.ReadLine(), out height);
            if (!decimalParsingResult)
            {
                Console.WriteLine("You've entered the wrong value");
                Console.WriteLine("Program ended.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"It's nice to meet you, {name}");
            Console.WriteLine($"You are {age} old. You will be {age + 10} in ten years");
            if (youAreAdult)
            {
                Console.WriteLine($"You are adult!");
            }
            Console.WriteLine($"You are {height}m tall. It is {height * 100}cm");
            Console.ReadLine();
        }
    }
}
