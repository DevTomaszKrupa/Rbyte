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
            string name = Console.ReadLine();

            // Concatenation by multiple Write method call.
            Console.Write("It's nice to meet you, ");
            Console.Write(name);
            Console.Write(Environment.NewLine);

            // Concatenation by '+'
            Console.WriteLine("It's nice to meet you, " + name);

            // Concatenation by string.Concat
            Console.WriteLine(string.Concat("It's nice to meet you, ", name));

            // Concatenation by WriteLine args
            Console.WriteLine("It's nice to meet you, {0}", name);

            // Concatenation by new .net standard
            Console.WriteLine($"It's nice to meet you, {name}");
        }
    }
}
