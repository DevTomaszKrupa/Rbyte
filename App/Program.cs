using System;
using System.Collections.Generic;

namespace Rbyte.App
{
    class Program
    {   // TODO: komentarze
        // TODO: pokazac mozliwości Enum (GetName), (GetValue)
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

        public static void ExecuteSelectedOption(MenuOptionEnum choice)
        {
            switch (choice)
            {
                case MenuOptionEnum.ShowCurrentTime:
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss"));
                    return;
                case MenuOptionEnum.ShowCurrentDate:
                    Console.WriteLine(DateTime.Now.ToString("dd MMM yyyy"));
                    return;
                case MenuOptionEnum.ShowDayOfTheWeek:
                    Console.WriteLine(DateTime.Now.DayOfWeek);
                    return;
                case MenuOptionEnum.ShowFullDate:
                    Console.WriteLine(DateTime.Now.ToString("dd MMM yyyy, hh:mm:ss"));
                    return;
            }
        }
        public static MenuOptionEnum ChooseMenuOption()
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
                        return MenuOptionEnum.ShowCurrentTime;
                    case "2":
                        return MenuOptionEnum.ShowCurrentDate;
                    case "3":
                        return MenuOptionEnum.ShowDayOfTheWeek;
                    case "4":
                        return MenuOptionEnum.ShowFullDate;
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

    public enum MenuOptionEnum
    {
        ShowCurrentTime = 1,
        ShowCurrentDate = 2,
        ShowDayOfTheWeek = 3,
        ShowFullDate = 4
    }
}
