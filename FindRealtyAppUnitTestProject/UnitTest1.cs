using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FindRealtyApp.Models;
using FindRealtyApp.Repositories;
using System.Data.SqlClient;

namespace FindRealtyAppUnitTestProject
{
    [TestClass]
    public class ClientRepositoryTest
    {
        [TestMethod]
        public void AddClientTest_ReturnTrue()
        {
            string firstName = "test";
            string lastName = "test";
            string patronymic = "test";
            string email = "test";
            string phone = "test";
            bool expected = true;
            bool result;

            string connectionString = "Data Source=KRUTYASH;Initial Catalog=EntireWorld;User ID=sa;Password=123;Connect Timeout=5;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client() { FirstName = firstName, LastName = lastName, Patronymic = patronymic, Email= email, Phone= phone};
            clientRepository.Add(client);
            using (SqlConnection connection = sqlConnection)
            {
                connection.Open();
                string query = "Select * From ViewClient WHERE FirstName = @FirstName AND LastName = @LastName AND Patronymic = @Patronymic AND Email = @Email AND Phone = @Phone";
                var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                sqlCommand.Parameters.AddWithValue("@Patronymic", patronymic);
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@Phone", phone);
                result = sqlCommand.ExecuteScalar() == null ? false : true;

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void RemoveClientTest_ReturnTrue()
        {
            string firstName = "test";
            string lastName = "test";
            string patronymic = "test";
            string email = "test";
            string phone = "test";
            bool expected = true;
            bool result;

            string connectionString = "Data Source=KRUTYASH;Initial Catalog=EntireWorld;User ID=sa;Password=123;Connect Timeout=5;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            ClientRepository clientRepository = new ClientRepository();
            Client client = new Client() { FirstName = firstName, LastName = lastName, Patronymic = patronymic, Email = email, Phone = phone };
            clientRepository.Add(client);
            clientRepository.Remove(client);
            using (SqlConnection connection = sqlConnection)
            {
                connection.Open();
                string query = "Select * From ViewClient WHERE FirstName = @FirstName AND LastName = @LastName AND Patronymic = @Patronymic AND Email = @Email AND Phone = @Phone";
                var sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);
                sqlCommand.Parameters.AddWithValue("@Patronymic", patronymic);
                sqlCommand.Parameters.AddWithValue("@Email", email);
                sqlCommand.Parameters.AddWithValue("@Phone", phone);
                result = sqlCommand.ExecuteScalar() == null ? false : true;

                Assert.AreEqual(expected, result);
            }
        }
    }
}
