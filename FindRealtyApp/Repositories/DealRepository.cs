using FindRealtyApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Repositories
{
    class DealRepository : RepositoryBase
    {
        public IEnumerable<Deal> GetAllRealEstates()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM ViewDeals";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var deals = new List<Deal>();
                    while (reader.Read())
                    {
                        var deal = new Deal();
                        deal.Id = reader.GetInt32(0);
                        deal.Address = reader.GetString(1);
                        deal.Client = reader.GetString(2);
                        deal.Agent = reader.GetString(3);


                        deals.Add(deal);
                    }
                    return deals;
                }
            }
        }

    }
}
