using FindRealtyApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindRealtyApp.Repositories
{
    public class ClientRepository : RepositoryBase
    {
        public IEnumerable<Client> GetAllClients()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM ViewClient";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var clients = new List<Client>();
                    while (reader.Read())
                    {
                        var client = new Client();
                        client.Id = reader.GetInt32(0);
                        client.Phone = reader.GetString(4);
                        client.Email = reader.GetString(5);
                        client.FirstName = reader.GetString(1);
                        client.LastName = reader.GetString(2);
                        client.Patronymic = reader.GetString(3);
                        clients.Add(client);
                    }
                    return clients;
                }         
            }
        }
        public void Add(Client client)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Person (FirstName, LastName, Patronymic) VALUES (@FirstName, @LastName, @Patronymic)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@FirstName", $"{client.FirstName}");
                command.Parameters.AddWithValue("@LastName", $"{client.LastName}");
                command.Parameters.AddWithValue("@Patronymic", $"{client.Patronymic}");

                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT TOP 1 ID FROM Person ORDER BY Id DESC", connection);
                var id = command.ExecuteScalar();

                query = "INSERT INTO Client (Id,Phone, Email) VALUES (@Id, @Phone, @Email)";
                command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Id", $"{id}");
                command.Parameters.AddWithValue("@Phone", $"{client.Phone}");
                command.Parameters.AddWithValue("@Email", $"{client.Email}");

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Remove(Client client)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "DELETE FROM Person WHERE Id = @Id";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", $"{client.Id}");
                sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Edit(Client client)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "UPDATE PERSON SET FirstName = @FirstName, LastName = @LastName, Patronymic = @Patronymic WHERE ID = @Id";

                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", client.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", client.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", client.LastName);
                sqlCommand.Parameters.AddWithValue("@Patronymic", client.Patronymic);

                sqlCommand.ExecuteNonQuery();

                query = "UPDATE CLIENT SET Phone = @Phone, Email = @Email WHERE ID = @Id";

                sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Id", client.Id);
                sqlCommand.Parameters.AddWithValue("@Phone", client.Phone);
                sqlCommand.Parameters.AddWithValue("@Email", client.Email);

                sqlCommand.ExecuteNonQuery();
                connection.Close();

            }
        }

        public IEnumerable<Agent> GetAllAgents()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM ViewAgent";
                SqlCommand command = new SqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    var agents = new List<Agent>();
                    while (reader.Read())
                    {
                        var agent = new Agent();
                        agent.Id = reader.GetInt32(0);
                        agent.FirstName = reader.GetString(1);
                        agent.LastName = reader.GetString(2);
                        agent.Patronymic = reader.GetString(3);
                        agent.DealShare = reader.GetInt32(4);
                        agents.Add(agent);
                    }
                    return agents;
                }
            }
        }
    }
}
