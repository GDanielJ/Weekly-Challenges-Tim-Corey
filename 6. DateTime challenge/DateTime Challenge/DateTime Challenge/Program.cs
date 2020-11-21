using System;

namespace DateTime_Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me a date: ");
            var dateInput = Console.ReadLine();

            var daysAgo = (DateTime.Now - DateTime.Parse(dateInput)).TotalDays;

            Console.WriteLine($"It has been {Math.Round(daysAgo, 2)} days ago since {dateInput}");

            Console.WriteLine("Give me a time: ");
            var timeInput = Console.ReadLine();

            var timeAgo = DateTime.Now.Subtract(DateTime.Parse(timeInput));

            Console.WriteLine($"{timeInput} was {timeAgo.Hours} hours and {timeAgo.Minutes} minutes ago");

            Console.ReadLine();
        }
    }
}
