using System;
using System.Collections.Generic;

namespace Rbyte.App
{
    class Program
    {   // TODO: komentarze
        static void Main(string[] args)
        {
            var listOfStrings = new List<string>(); // using System.Collections.Generic;
            int repeats;
            while (!int.TryParse(Console.ReadLine(), out repeats))
            {
                Console.WriteLine("This is not a number! Try Again");
            }

            for (int i = 0; i < repeats; i++)
            {
                var txt = Console.ReadLine();
                listOfStrings.Add(txt);
            }

            var index = 1;
            foreach (var item in listOfStrings)
            {
                Console.WriteLine($"Element no. {1}: {item}");
                index++;
            }

            Console.ReadLine();
        }
    }
}
