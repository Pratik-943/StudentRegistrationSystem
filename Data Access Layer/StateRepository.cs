using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Lab_9.Entity_Layer;

namespace Lab_9.Data_Access_Layer
{
    public class StateRepository : IStateRepository
    {
        public List<State> GetStates()
        {
            List<State> list =
                new List<State>();

            using (SqlConnection con =
                   DbHelper.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM State",
                        con);
                con.Open();
                SqlDataReader dr =
                    cmd.ExecuteReader();
                while (dr.Read())
                {
                    State s =
                        new State();
                    s.StateId =
                        Convert.ToInt32(
                            dr["StateId"]);
                    s.StateName =
                        dr["StateName"]
                        .ToString();

                    list.Add(s);
                }
            }
            return list;
        }

        public List<City> GetCitiesByState(int stateId)
        {
            List<City> list =
                new List<City>();

            using (SqlConnection con =
                   DbHelper.GetConnection())
            {
                SqlCommand cmd =
                    new SqlCommand(
                        "SELECT * FROM City WHERE StateId=@StateId",
                        con);

                cmd.Parameters.AddWithValue(
                    "@StateId",
                    stateId);

                con.Open();

                SqlDataReader dr =
                    cmd.ExecuteReader();
                while (dr.Read())
                {
                    City c =
                        new City();
                    c.CityId =
                        Convert.ToInt32(
                            dr["CityId"]);
                    c.CityName =
                        dr["CityName"]
                        .ToString();
                    c.StateId =
                        Convert.ToInt32(
                            dr["StateId"]);
                    list.Add(c);
                }
            }
            return list;
        }
    }
}