using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperDemoLibrary
{
    public class DataAccess
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DapperDemoDB"].ConnectionString;
        }

        public List<SystemUserModel> ReadUsers(string proc, object p)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<SystemUserModel>(proc, p, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void WriteUser(string proc, object p)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(proc, p, commandType: CommandType.StoredProcedure);
            }
        }



        //////////////////////////////////////// Code from main challenge below: ///////////////////////////////////////////////

        //public List<SystemUserModel> GetUsers()
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        return cnn.Query<SystemUserModel>("spSystemUser_Get", commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}

        //public List<SystemUserModel> GetFilteredUsers(string filter)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        var p = new
        //        {
        //            Filter = filter
        //        };

        //        return cnn.Query<SystemUserModel>("spSystemUser_GetFiltered", p, commandType: CommandType.StoredProcedure).ToList();
        //    }
        //}

        //public void WriteUser(string FirstName, string LastName)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        var p = new
        //        {
        //            FirstName,
        //            LastName
        //        };

        //        cnn.Execute("dbo.spSystemUser_Create", p, commandType: CommandType.StoredProcedure);
        //    }
        //}
    }
}
