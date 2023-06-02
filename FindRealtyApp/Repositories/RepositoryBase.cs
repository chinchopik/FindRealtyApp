using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Repositories
{
    public abstract class RepositoryBase
    {
        private static readonly string _connectionString;
        static RepositoryBase()
        {
            _connectionString = "Data Source=KRUTYASH;Initial Catalog=EntireWorld;User ID=sa;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
