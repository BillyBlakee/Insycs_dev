using Insycs_dev.Pages.DB;
using Insycs_dev.Pages.DataClasses;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Insycs_dev.Pages.DB
{
    public class DBClass
    {
        public static SqlConnection ProdDBConn = new SqlConnection();

        //Local Host Connection String
        public static readonly String ProdDBConnString = "Server = Localhost;Database = Prod;Trusted_Connection = True;TrustServerCertificate=true;";
        public static readonly String AuthConnString = "Server = LocalHost;Database = AUTH;Trusted_Connection = True;TrustedServerCertificate=true";
        //AWS Connection String


        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            using (var connection = new SqlConnection(ProdDBConnString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SELECT UserID, FirstName, LastName, Email, PhoneNumber, Username FROM [Users]";

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                            Username = reader.GetString(reader.GetOrdinal("Username")),
                            
                        });
                    }
                }
            }
            return users;
        }

        public static int LoginQuery(string loginQuery)
        {
            // This method expects to receive an SQL SELECT
            // query that uses the COUNT command.
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = ProdDBConn;
            cmdLogin.Connection.ConnectionString = ProdDBConnString;
            cmdLogin.CommandText = loginQuery;
            cmdLogin.Connection.Open();
            // ExecuteScalar() returns back data type Object
            // Use a typecast to convert this to an int.
            // Method returns first column of first row.
            int rowCount = (int)cmdLogin.ExecuteScalar();
            return rowCount;
        }



        public static void CreateHashedUser(string Username, string Password)
        {
            string loginQuery = "Insert into HashedCredentials (Username, Password) values (@Username, @Password)";

            using (SqlConnection connection = new SqlConnection(AuthConnString))
            {
                using (SqlCommand cmdLogin = new SqlCommand(loginQuery, connection))
                {
                    cmdLogin.Parameters.Add("@Username", SqlDbType.VarChar).Value = Username;
                    cmdLogin.Parameters.Add("@Password", SqlDbType.VarChar).Value = PasswordHash.HashPassword(Password);


                    connection.Open();

                    cmdLogin.ExecuteNonQuery();
                }
            }
        }


        public static bool HashedParameterLogin(string Username, string Password)
        {
            string loginQuery = "SELECT * from HashedCredentials Where Username = @Username";

            using (SqlConnection connection = new SqlConnection(AuthConnString))
            {
                using (SqlCommand cmdLogin = new SqlCommand(loginQuery, connection))
                {
                    cmdLogin.Parameters.AddWithValue("@Username", Username);

                    connection.Open();

                    using (SqlDataReader hashReader = cmdLogin.ExecuteReader())
                    {
                        if (hashReader.Read())
                        {
                            string correctHash = hashReader["Password"].ToString();

                            if (PasswordHash.ValidatePassword(Password, correctHash))
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public static int GetUserIDByName(string userName)
        {
            int userID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(ProdDBConnString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT UserID FROM [User] WHERE userName = @UserName", connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            userID = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (log, throw, or handle as appropriate)
                Console.WriteLine($"Error in GetUserIDByName: {ex.Message}");
                // You might want to log or throw the exception, or handle it in a way that's suitable for your application.
            }

            return userID;
        }

        //Functions For Properties Pages

        public void AddProperty(int userId, string propertyType, decimal propertyValue, string location, DateTime purchaseDate)
        {
            string query = "INSERT INTO Properties (UserID, PropertyType, PropertyValue, Location, PurchaseDate) VALUES (@UserID, @PropertyType, @PropertyValue, @Location, @PurchaseDate)";

            using (SqlConnection connection = new SqlConnection(ProdDBConnString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@PropertyType", propertyType);
                    command.Parameters.AddWithValue("@PropertyValue", propertyValue);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@PurchaseDate", purchaseDate);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
