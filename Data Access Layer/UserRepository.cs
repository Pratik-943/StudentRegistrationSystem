using Lab_9.Data_Access_Layer;
using Lab_9.Entity_Layer;
using System;
using System.Data.SqlClient;

namespace StudentRegistrationSystem.Data_Access_Layer
{
    public class UserRepository : IUserRepository
    {
        public void Insert(User u)
        {
            using (SqlConnection con =
                DbHelper.GetConnection())
            {
                string query =
                    @"INSERT INTO Users
                      (Name,Email,Password)
                      VALUES
                      (@Name,@Email,@Password)";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", u.Name);
                cmd.Parameters.AddWithValue("@Email", u.Email);
                cmd.Parameters.AddWithValue("@Password", u.Password);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public User Login(string email, string password)
        {
            User user = null;

            using (SqlConnection con =
                DbHelper.GetConnection())
            {
                string query =
                    @"SELECT * FROM Users
                      WHERE Email=@Email
                      AND Password=@Password";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    user = new User();

                    user.UserId =
                        Convert.ToInt32(dr["UserId"]);

                    user.Name =
                        dr["Name"].ToString();

                    user.Email =
                        dr["Email"].ToString();
                }
            }

            return user;
        }
    }
}