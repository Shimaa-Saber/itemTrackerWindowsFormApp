using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskForTrackItem.Models.Models;

namespace itemTracker.DAL.Repos
{
    public class UserRepository
    {
        public User GetUserByUsername(string username)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Users WHERE Username = @Username";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserID = (int)reader["UserID"],
                                Username = reader["Username"].ToString(),
                                PasswordHash = reader["PasswordHash"].ToString(),
                                Role = reader["Role"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void AddUser(User user)
        {
            using (var conn = DbHelper.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@Role", user.Role);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
