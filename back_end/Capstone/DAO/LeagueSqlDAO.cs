using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class LeagueSqlDAO : ILeagueDAO
    {
        private readonly string connectionString;

        public LeagueSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<League> GetAllLeagues()
        {
            List<League> returnLeague = new List<League>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM league", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            League l = GetLeagueFromReader(reader);
                            returnLeague.Add(l);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnLeague;
        }

        public League GetLeague(string leagueName)
        {
            League returnLeague = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT league_id, league_name, league_admin, course_id, league_start, league_end, score_league, user_id FROM league WHERE league_name = @leagueName", conn);
                    cmd.Parameters.AddWithValue("@leagueName", leagueName);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnLeague = GetLeagueFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnLeague;
        }

        public List<League> ListLeaguesByUser(string username )
        {
            List<League> returnLeague = new List<League>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select * from league join league_users on league.league_id = league_users.league_id join users on users.user_id = league_users.user_id where username = @username", conn);
                    cmd.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            League l = GetLeagueFromReader(reader);
                            returnLeague.Add(l);
                        }

                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnLeague;
        }

        public League AddLeague(League league)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO league (league_name, league_admin, course_id, league_start, league_end, score_league) VALUES (@league_name, @league_admin, @course_id, @league_start, @league_end, @score_league)", conn);                    
                    cmd.Parameters.AddWithValue("@league_name", league.LeagueName);
                    cmd.Parameters.AddWithValue("@league_admin", league.LeagueAdmin);
                    cmd.Parameters.AddWithValue("@course_id", league.CourseId);
                    cmd.Parameters.AddWithValue("@league_start", league.StartDate);
                    cmd.Parameters.AddWithValue("@league_end", league.EndDate);
                    cmd.Parameters.AddWithValue("@score_league", league.ScoreLeague);
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
        
        private League GetLeagueFromReader(SqlDataReader reader)
        {
            League l = new League()
            {
                LeagueId = Convert.ToInt32(reader["league_id"]),
                LeagueName = Convert.ToString(reader["league_name"]),
                LeagueAdmin = Convert.ToString(reader["league_admin"]),
                CourseId = Convert.ToInt32(reader["course_id"]),
                StartDate = Convert.ToDateTime(reader["league_start"]),
                 EndDate = Convert.ToDateTime(reader["league_end"]),
                ScoreLeague = Convert.ToBoolean(reader["score_league"]),
            };

            return l;
        }
    }
}