using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemoLibrary
{
    public class BusinessLayer
    {
        DataAccess dataAccess = new DataAccess();
        public List<SystemUserModel> GetUsers()
        {
            return dataAccess.ReadUsers("spSystemUser_Get", new { });
        }

        public List<SystemUserModel> GetFilteredUsers(string filter)
        {
            var p = new
            {
                Filter = filter
            };

            return dataAccess.ReadUsers("spSystemUser_GetFiltered", p);
        }

        public void CreateUser(string firstName, string lastName)
        {
            var p = new
            {
                FirstName = firstName,
                LastName = lastName
            };

            dataAccess.WriteUser("dbo.spSystemUser_Create", p);
        }
    }
}
