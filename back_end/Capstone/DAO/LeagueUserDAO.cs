using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Capstone.DAO
{
    public class LeagueUserDAO : ILeagueUserDAO

    {
        private readonly string connectionString;

        public LeagueUserDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public LeagueUser JoinLeague(LeagueUser league)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO league_users (league_id, user_id) VALUES (@league_id, @user_id)", conn);
                    cmd.Parameters.AddWithValue("@league_id", league.LeagueId);
                    cmd.Parameters.AddWithValue("@user_id", league.UserId);                    
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {

                        league = GetLeagueFromReader(reader);
                    }

                }
            }
            catch (SqlException)
            {
                throw;
            }

            return league;
        }

        public List<LeagueUser> GetLeagueUsers()
        {
            List<LeagueUser> returnLeagueUsers = new List<LeagueUser>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM league_users", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            LeagueUser l = GetLeagueFromReader(reader);
                            returnLeagueUsers.Add(l);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnLeagueUsers;
        }

        private LeagueUser GetLeagueFromReader(SqlDataReader reader)
        {
            LeagueUser l = new LeagueUser()
            {
                LeagueId = Convert.ToInt32(reader["league_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),
               
            };

            return l;
        }
    }
}
