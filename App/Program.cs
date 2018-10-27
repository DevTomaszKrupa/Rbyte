using System;

namespace Rbyte.App
{
    class Program
    {   // TODO: komentarze
        static void Main(string[] args)
        {
            var now = DateTime.Now;
            Console.WriteLine($"Without format:                    {now}");
            Console.WriteLine($"ToShortDateString:                 {now.ToShortDateString()}");
            Console.WriteLine($"ToShortTimeString:                 {now.ToShortTimeString()}");
            Console.WriteLine($"ToLongDateString:                  {now.ToLongDateString()}");
            Console.WriteLine($"ToLongTimeString:                  {now.ToLongTimeString()}");
            Console.WriteLine($"MM/dd/yyyy                         " + now.ToString("MM/dd/yyyy"));
            Console.WriteLine($"MM/dd/yyyy hh:mm:ss                " + now.ToString("MM/dd/yyyy hh:mm:ss"));
            Console.WriteLine($"MM/dd/yyyy hh:mm                   " + now.ToString("MM/dd/yyyy hh:mm"));
            Console.WriteLine($"dd : MMM : yy                      " + now.ToString("dd : MMM : yy"));

            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Insert date [correct format is: dd.mm.yyyy hh:mm or dd/mm/yyyy, etc.]");
            var yourDateStr = Console.ReadLine();
            DateTime yourDate;
            var dateParsingResult = DateTime.TryParse(yourDateStr, out yourDate);

            while (!dateParsingResult)
            {
                dateParsingResult = DateTime.TryParse(Console.ReadLine(), out yourDate);
            }

            Console.WriteLine("Correct date!");
            Console.WriteLine(yourDate);

            Console.ReadLine();
        }
    }
}
