﻿using System;

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
            
            Console.WriteLine("How old are you?");
            string ageStr = Console.ReadLine();

            Console.WriteLine("How tall are you? [m]");
            string heightStr = Console.ReadLine();

            decimal height = decimal.Parse(heightStr);

            int age = int.Parse(ageStr);
            bool youAreAdult = age >= 18;

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
