using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            for (int i = 0; i <= 10; i++)
            {
                try
                {
                    var result = paymentProcessor.MakePayment($"Demo{ i }", i);

                    if (result == null)
                    {
                        Console.WriteLine($"Null value for item {i}");
                    }
                    else
                    {
                        Console.WriteLine(result.TransactionAmount);
                    }
                }
                catch (Exception e)
                {
                    string innerExceptionMessage = e.InnerException == null ? "" : e.InnerException.Message;

                    if (e is IndexOutOfRangeException)
                    {
                        Console.WriteLine($"Skipped invalid record {innerExceptionMessage}");
                    }
                    else if (e is FormatException && i != 5)
                    {
                        Console.WriteLine($"Formatting issue {innerExceptionMessage}");
                    }
                    else
                    {
                        Console.WriteLine($"Payment skipped for payment with {i} items");
                    }     
                }
            }
            Console.ReadLine();
        }
    }
}
