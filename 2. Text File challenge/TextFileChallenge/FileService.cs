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
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var user = new UserModel();

                    var line = reader.ReadLine();
                    string[] values = line.Split(',');

                    user.FirstName = values[0];
                    user.LastName = values[1];
                    user.Age = int.Parse(values[2]);
                    user.IsAlive = Convert.ToBoolean(Convert.ToInt32(values[3]));

                    users.Add(user);
                }

                return users;
            }
        }

        public void SaveUsers(BindingList<UserModel> users, string path)
        {
            using(var writer = new StreamWriter(path, false))
            {
                foreach (var user in users)
                {
                    int isAliveInt = user.IsAlive == true ? 1 : 0;

                    string line = $"{user.FirstName},{user.LastName},{user.Age},{isAliveInt}";

                    writer.WriteLine(line);
                }
            }
        }
    }
}
