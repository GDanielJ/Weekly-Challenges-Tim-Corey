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
            // Main challenge //
            string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            string appSetting = ConfigurationManager.AppSettings["TempFilePath"];

            Console.WriteLine(connectionString);
            Console.WriteLine(appSetting);

            Console.ReadLine();

            // Bonus challenge //

            var connectionStrings = ConfigurationManager.ConnectionStrings;

            foreach (ConnectionStringSettings cS in connectionStrings)
            {
                Console.WriteLine($"Name: {cS.Name}, Value: {cS.ConnectionString}");
            }

            Console.ReadLine();

            var appSettings = ConfigurationManager.AppSettings;

            foreach (var key in appSettings.AllKeys)
            {
                Console.WriteLine($"Key: {key}, Value: {appSettings[key]}");
            }

            Console.ReadLine();

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string newKey = "NewKey";
            string newValue = "NewValue";

            config.AppSettings.Settings.Add(newKey, newValue);
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");

            appSettings = ConfigurationManager.AppSettings;

            foreach (var key in appSettings.AllKeys)
            {
                Console.WriteLine($"Key: {key}, Value: {appSettings[key]}");
            }

            Console.ReadLine();
        }
    }
}
