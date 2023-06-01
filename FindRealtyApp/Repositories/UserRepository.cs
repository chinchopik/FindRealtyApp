using FindRealtyApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Repositories
{
    class UserRepository : RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(string username, string password)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [User] where login=@username and password=@password";
                command.Parameters.Add("@username", System.Data.SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@password", System.Data.SqlDbType.NVarChar).Value = password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }
    }
}
