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
                        realEstate.Address = reader.GetString(1);
                        realEstate.Price = reader.GetInt32(2);
                        realEstates.Add(realEstate);
                    }
                    return realEstates;
                }
            }
        }

        public IEnumerable<House> GetHouses()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM ViewRealEstatesHouses";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var houses = new List<House>();
                    while (reader.Read())
                    {
                        var realEstate = new House();
                        realEstate.Id = reader.GetInt32(0);
                        realEstate.Address = reader.GetString(1);
                        realEstate.TotalFloors = reader.GetInt32(2);
                        realEstate.TotalArea = reader.GetDouble(3);
                        realEstate.Price = reader.GetInt32(4);
                        houses.Add(realEstate);
                    }
                    return houses;
                }
            }
        }

        public IEnumerable<Apartment> GetApartments()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM ViewRealEstatesApartments";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var apartments = new List<Apartment>();
                    while (reader.Read())
                    {
                        var realEstate = new Apartment();
                        realEstate.Id = reader.GetInt32(0);
                        realEstate.Address = reader.GetString(1);
                        realEstate.TotalFloors = reader.GetInt32(2);
                        realEstate.TotalArea = reader.GetDouble(3);
                        realEstate.NumberOfRooms = reader.GetInt32(4);
                        realEstate.Price = reader.GetInt32(5);
                        apartments.Add(realEstate);
                    }
                    return apartments;
                }
            }
        }

        public IEnumerable<Land> GetLands()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM ViewRealEstatesLands";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var lands = new List<Land>();
                    while (reader.Read())
                    {
                        var realEstate = new Land();
                        realEstate.Id = reader.GetInt32(0);
                        realEstate.Address = reader.GetString(1);
                        realEstate.TotalArea = reader.GetDouble(2);
                        realEstate.Price = reader.GetInt32(3);
                        lands.Add(realEstate);
                    }
                    return lands;
                }
            }
        }

        public void AddHouse(House house)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO RealEstate (Address, Price) VALUES (@Address, @Price)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Address", $"{house.Address}");
                command.Parameters.AddWithValue("@Price", $"{house.Price}");

                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT TOP 1 ID FROM RealEstate ORDER BY Id DESC", connection);
                var id = command.ExecuteScalar();

                query = "INSERT INTO House (Id,TotalFloors, TotalArea) VALUES (@Id, @TotalFloors, @TotalArea)";
                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", $"{id}");
                command.Parameters.AddWithValue("@TotalFloors", $"{house.TotalFloors}");
                command.Parameters.AddWithValue("@TotalArea", System.Data.SqlDbType.Float).Value = house.TotalArea;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddLand(Land land)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO RealEstate (Address, Price) VALUES (@Address, @Price)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Address", $"{land.Address}");
                command.Parameters.AddWithValue("@Price", $"{land.Price}");

                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT TOP 1 ID FROM RealEstate ORDER BY Id DESC", connection);
                var id = command.ExecuteScalar();

                query = "INSERT INTO Land (Id, TotalArea) VALUES (@Id, @TotalArea)";
                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", $"{id}");
                command.Parameters.AddWithValue("@TotalArea", System.Data.SqlDbType.Float).Value = land.TotalArea;

                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void AddApartment(Apartment apartment)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO RealEstate (Address, Price) VALUES (@Address, @Price)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Address", $"{apartment.Address}");
                command.Parameters.AddWithValue("@Price", $"{apartment.Price}");

                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT TOP 1 ID FROM RealEstate ORDER BY Id DESC", connection);
                var id = command.ExecuteScalar();

                query = "INSERT INTO Apartments (Id,TotalFloors, TotalArea, NumberOfRooms) VALUES (@Id, @TotalFloors, @TotalArea, @NumberOfRooms)";
                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", $"{id}");
                command.Parameters.AddWithValue("@TotalFloors", $"{apartment.TotalFloors}");
                command.Parameters.AddWithValue("@TotalArea", System.Data.SqlDbType.Float).Value = apartment.TotalArea;
                command.Parameters.AddWithValue("@NumberOfRooms", $"{apartment.NumberOfRooms}");

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditLand(Land land)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "UPDATE RealEstate SET Address = @Address, Price = @Price WHERE ID = @Id";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", land.Id);
                sqlCommand.Parameters.AddWithValue("@Address", land.Address);
                sqlCommand.Parameters.AddWithValue("@Price", land.Price);

                sqlCommand.ExecuteNonQuery();

                query = "UPDATE Land SET TotalArea = @TotalArea WHERE ID = @Id";

                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", land.Id);
                sqlCommand.Parameters.AddWithValue("@TotalArea", land.TotalArea);

                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void EditHouse(House house)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "UPDATE RealEstate SET Address = @Address, Price = @Price WHERE ID = @Id";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", house.Id);
                sqlCommand.Parameters.AddWithValue("@Address", house.Address);
                sqlCommand.Parameters.AddWithValue("@Price", house.Price);

                sqlCommand.ExecuteNonQuery();

                query = "UPDATE House SET TotalArea = @TotalArea, TotalFloors = @TotalFloors WHERE ID = @Id";

                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", house.Id);
                sqlCommand.Parameters.AddWithValue("@TotalArea", house.TotalArea);
                sqlCommand.Parameters.AddWithValue("@TotalFloors", house.TotalFloors);

                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void EditApartment(Apartment apartment)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "UPDATE RealEstate SET Address = @Address, Price = @Price WHERE ID = @Id";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", apartment.Id);
                sqlCommand.Parameters.AddWithValue("@Address", apartment.Address);
                sqlCommand.Parameters.AddWithValue("@Price", apartment.Price);

                sqlCommand.ExecuteNonQuery();

                query = "UPDATE Apartment SET TotalArea = @TotalArea, TotalFloors = @TotalFloors, NumberOfRooms =@NumberOfRooms WHERE ID = @Id";

                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", apartment.Id);
                sqlCommand.Parameters.AddWithValue("@TotalArea", apartment.TotalArea);
                sqlCommand.Parameters.AddWithValue("@TotalFloors", apartment.TotalFloors);
                sqlCommand.Parameters.AddWithValue("@NumberOfRooms", apartment.NumberOfRooms);

                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void Remove(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM RealEstate WHERE Id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", $"{id}");
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}
