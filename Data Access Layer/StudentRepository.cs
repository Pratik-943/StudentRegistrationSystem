using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Lab_9.Entity_Layer;
using System.Configuration;

namespace Lab_9.Data_Access_Layer
{
    public class StudentRepository : IStudentRepository
    {
        string cs = ConfigurationManager.ConnectionStrings["db"].ConnectionString;

        public void Insert(Student s)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "INSERT INTO Student VALUES (@Name,@Phone,@Email,@Address,@Gender,@Language,@StateId,@CityId,@Photo)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", (object)s.Name ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object)s.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)s.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)s.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object)s.Gender ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Language", (object)s.Language ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StateId", s.StateId);
                cmd.Parameters.AddWithValue("@CityId", s.CityId);
                cmd.Parameters.AddWithValue("@Photo", (object)s.Photo ?? DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Student> GetAll()
        {
            List<Student> list = new List<Student>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Student
                    {
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        Name = dr["Name"].ToString(),
                        Email = dr["Email"].ToString(),
                        Phone = dr["Phone"].ToString()
                    });
                }
            }
            return list;
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE StudentId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Student s)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "UPDATE Student SET Name=@Name, Phone=@Phone, Email=@Email, Address=@Address, Gender=@Gender, Language=@Language, StateId=@StateId, CityId=@CityId, Photo=ISNULL(@Photo, Photo) WHERE StudentId=@Id";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Name", (object)s.Name ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", (object)s.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)s.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Address", (object)s.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Gender", (object)s.Gender ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Language", (object)s.Language ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@StateId", s.StateId);
                cmd.Parameters.AddWithValue("@CityId", s.CityId);
                cmd.Parameters.AddWithValue("@Photo", (object)s.Photo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Id", s.StudentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Student GetById(int id)
        {
            Student s = new Student();

            using (SqlConnection con = DbHelper.GetConnection())
            {
                string query =
                    "SELECT * FROM Student WHERE StudentId=@Id";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();

                if (dr.Read())
                {
                    s.StudentId =
                        Convert.ToInt32(dr["StudentId"]);

                    s.Name =
                        dr["Name"].ToString();

                    s.Phone =
                        dr["Phone"].ToString();

                    s.Email =
                        dr["Email"].ToString();

                    s.Address =
                        dr["Address"].ToString();

                    s.Gender =
                        dr["Gender"].ToString();

                    s.Language =
                        dr["Language"].ToString();

                    s.StateId =
                        Convert.ToInt32(dr["StateId"]);

                    s.CityId =
                        Convert.ToInt32(dr["CityId"]);

                    s.Photo =
                        dr["Photo"].ToString();
                }
            }

            return s;
        }
    }
}