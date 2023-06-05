using FindRealtyApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Repositories
{
    class RealEstateRepository : RepositoryBase
    {
        public IEnumerable<RealEstate> GetAllRealEstates()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM RealEstate";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var realEstates = new List<RealEstate>();
                    while (reader.Read())
                    {
                        var realEstate = new RealEstate();
                        realEstate.Id = reader.GetInt32(0);
                        realEstate.AddressCity = reader.GetString(1);
                        realEstate.AddressStreet = reader.GetString(2);
                        realEstate.AddressHouse = reader.GetString(3);
                        realEstate.AddressNumber = reader.GetString(4);
                        realEstate.LatitudeCoordinate = reader.GetDouble(5);
                        realEstate.LongitudeCoordinate = reader.GetDouble(6);


                        realEstates.Add(realEstate);
                    }
                    return realEstates;
                }
            }
        }
    }
}
