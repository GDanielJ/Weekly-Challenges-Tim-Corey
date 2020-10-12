using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileChallenge
{
    public class FileService
    {
        public BindingList<UserModel> ReadUsers(string path)
        {
            BindingList<UserModel> users = new BindingList<UserModel>();

            using (var reader = new StreamReader(path))
            {
                var headerLine = reader.ReadLine();

                string[] headers = headerLine.Split(',');

                while (!reader.EndOfStream)
                {
                    var user = new UserModel();

                    var line = reader.ReadLine();
                    string[] values = line.Split(',');

                    user.FirstName = values[GetHeaderIndex(headers, "FirstName")];
                    user.LastName = values[GetHeaderIndex(headers, "LastName")];
                    user.Age = int.Parse(values[GetHeaderIndex(headers, "Age")]);
                    user.IsAlive = Convert.ToBoolean(Convert.ToInt32(values[GetHeaderIndex(headers, "IsAlive")]));

                    users.Add(user);
                }

                return users;
            }
        }

        public int GetHeaderIndex(string[] headers, string header)
        {
            return Array.IndexOf(headers, header);
        }

        public void SaveUsers(BindingList<UserModel> users, string path)
        {
            string headerLine = "";

            using(var reader = new StreamReader(path))
            {
                headerLine = reader.ReadLine();
            }

            using(var writer = new StreamWriter(path, false))
            {
                writer.WriteLine(headerLine);

                string[] headers = headerLine.Split(',');

                int indexFirstName = GetHeaderIndex(headers, "FirstName");
                int indexLastName = GetHeaderIndex(headers, "LastName");
                int indexAge = GetHeaderIndex(headers, "Age");
                int indexIsAlive = GetHeaderIndex(headers, "IsAlive");

                foreach (var user in users)
                {
                    string isAliveInt = user.IsAlive == true ? "1" : "0";

                    string[] outputLines = new string[4];

                    outputLines[indexFirstName] = user.FirstName;
                    outputLines[indexLastName] = user.LastName;
                    outputLines[indexAge] = user.Age.ToString();
                    outputLines[indexIsAlive] = isAliveInt;


                    string outputLine = $"{outputLines[0]},{outputLines[1]},{outputLines[2]},{outputLines[3]}";

                    writer.WriteLine(outputLine);
                }
            }
        }
    }
}
