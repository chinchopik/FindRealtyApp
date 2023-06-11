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
                        deal.Price = reader.GetInt32(4);
                        deal.Date = reader.GetDateTime(5);
                        deals.Add(deal);
                    }
                    return deals;
                }
            }

            
        }
        public void AddDeal(List<Deal> deals)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();          

                string query = "INSERT INTO Deal (IdRealEstate, IdClient, IdAgent, Date) VALUES (@IdRealEstate, @IdClient, @IdAgent, @Date)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@IdRealEstate", $"{deals.ElementAt(0).Address}");
                command.Parameters.AddWithValue("@IdClient", $"{deals.ElementAt(0).Client}");
                command.Parameters.AddWithValue("@IdAgent", $"{deals.ElementAt(0).Agent}");
                command.Parameters.AddWithValue("@Date", $"{deals.ElementAt(0).Date}");

                command.ExecuteNonQuery();

                connection.Close();
            }
        }    
    }
}
