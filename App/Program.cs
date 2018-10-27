using System;
using System.Collections.Generic;

namespace Rbyte.App
{
    class Program
    {   // TODO: komentarze
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Hello! Select an option...");
                var choice = ChooseMenuOption();
                Console.Clear();
                ExecuteSelectedOption(choice);
                Console.WriteLine("Click any enter to clear the console");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void ExecuteSelectedOption(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss"));
                    return;
                case 2:
                    Console.WriteLine(DateTime.Now.ToString("dd MMM yyyy"));
                    return;
                case 3:
                    Console.WriteLine(DateTime.Now.DayOfWeek);
                    return;
                case 4:
                    Console.WriteLine(DateTime.Now.ToString("dd MMM yyyy, hh:mm:ss"));
                    return;
            }
        }
        public static int ChooseMenuOption()
        {
            Console.WriteLine("1. Show current time");
            Console.WriteLine("2. Show current date");
            Console.WriteLine("3. Show day of the week");
            Console.WriteLine("4. Show full date");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return 1;
                    case "2":
                        return 2;
                    case "3":
                        return 3;
                    case "4":
                        return 4;
                }
            }
        }

        public static int ReadLineUntilNumber()
        {
            Console.WriteLine("Please enter the number");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {

            }
            return number;
        }
    }
}
