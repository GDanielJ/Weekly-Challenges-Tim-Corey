using System;
using System.Globalization;

namespace DateTime_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a date on format dd/MM/yy or MM/dd/yy: ");
            var dateInput = Console.ReadLine();

            Console.WriteLine("If you used format dd/MM/yy enter 1 and if you used format MM/dd/yy enter 2.");

            string inputFormat;
            double daysAgo;

            do
            {
                inputFormat = Console.ReadLine();

                if (int.Parse(inputFormat) == 1)
                {
                    daysAgo = (DateTime.Now - DateTime.ParseExact(dateInput, "dd/MM/yy", CultureInfo.InvariantCulture)).TotalDays;
                    break;
                }
                if (int.Parse(inputFormat) == 2)
                {
                    daysAgo = (DateTime.Now - DateTime.ParseExact(dateInput, "MM/dd/yy", CultureInfo.InvariantCulture)).TotalDays;
                    break;
                }
                Console.WriteLine("Please enter 1 or 2");
            } while (true);

            Console.WriteLine($"It has been {Math.Round(daysAgo, 2)} days ago since {dateInput}");

            Console.WriteLine("Give me a time: ");
            var timeInput = Console.ReadLine();

            var timeAgo = DateTime.Now.Subtract(DateTime.Parse(timeInput));

            if (timeAgo.Ticks < 0)
            {
                timeAgo = timeAgo.Add(TimeSpan.FromHours(24));
            }


            Console.WriteLine($"{timeInput} was {timeAgo.Hours} hours and {timeAgo.Minutes} minutes ago");

            Console.ReadLine();
        }
    }
}
