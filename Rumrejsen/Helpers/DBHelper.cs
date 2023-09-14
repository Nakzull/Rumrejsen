using Rumrejsen.Models;
using System.Data;
using System.Data.SqlClient;

namespace Rumrejsen.Helpers
{
    public class DBHelper
    {
        string connectionString = "Server=ZBC-E-CH-SKP047\\MSSQLSERVER01;Database=Rumrejse;Trusted_Connection=True;";

        //This method returns the users name, password and role from the DB.
        public async Task<User> GetUser(string name)
        {
            User user = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SelectUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name;

                        await using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Name = reader.GetString(0);
                                user.Password = reader.GetString(1);
                                user.Role = reader.GetString(2);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return user;
        }

        //This method adds the current JWT token to the user in the DB.
        public Task SaveToken(string name, string token)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SaveToken", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name;
                        command.Parameters.Add(new SqlParameter("@Token", SqlDbType.NVarChar, 255)).Value = token;
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return Task.CompletedTask;
        }

        //This method returns the role of a user in the DB based on the JWT token.
        public async Task<User> GetRole(string token)
        {
            User user = new User();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetRoleFromToken", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@Token", SqlDbType.NVarChar, 255)).Value = token;

                        await using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Role = reader.GetString(0);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return user;
        }

        //This method stores the time for the request made by the user in the DB.
        public Task StoreRequest(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("StoreRequest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@TimeStamp", SqlDbType.DateTime)).Value = DateTime.Now;
                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    command.ExecuteNonQuery();
                }
            }

            return Task.CompletedTask;
        }

        //This method returns the ID of a user in the DB.
        public async Task<int> GetId(string token)
        {
            int id = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@Token", SqlDbType.NVarChar, 255)).Value = token;

                        await using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                id = reader.GetInt32(0);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return id;
        }

        //This method returns a list of all requests made by the user from the DB.
        public async Task<List<DateTime>> GetRequests(int id)
        {
            List<DateTime> getRequests = new List<DateTime>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("GetRequests", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                        await using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                getRequests.Add(reader.GetDateTime(0));
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return getRequests;
        }
    }
}
