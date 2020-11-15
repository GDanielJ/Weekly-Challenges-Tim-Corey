using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string appSetting = ConfigurationManager.AppSettings["TempFilePath"];

            Console.WriteLine(connectionString);
            Console.WriteLine(appSetting);

            Console.ReadLine();
        }
    }
}
