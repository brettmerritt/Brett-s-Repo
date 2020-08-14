using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;


namespace Capstone.DAO
{
    public class LeaderboardSqlDAO : ILeaderboardDAO
    {
        private readonly string connectionString;

        public LeaderboardSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public List<Leaderboard> GetAllScores()
        {
            List<Leaderboard> returnLeaderboard = new List<Leaderboard>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM leaderboard", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Leaderboard l = GetLeaderboardFromReader(reader);
                            returnLeaderboard.Add(l);
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return returnLeaderboard;
        }

        public Leaderboard AddScore(Leaderboard score)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO leaderboard (week, total_score) VALUES (@week, @total_score)", conn);
                    cmd.Parameters.AddWithValue("@week", score.Week);
                    cmd.Parameters.AddWithValue("@total_score", score.TotalScore);
/*                    cmd.Parameters.AddWithValue("@league_id", score.LeagueId);
                    cmd.Parameters.AddWithValue("@user_id", score.UserId);*/
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                {

                    score = GetLeaderboardFromReader(reader);
                }

            }
            }
            catch (SqlException)
            {
                throw;
            }

            return score;
        }
private Leaderboard GetLeaderboardFromReader(SqlDataReader reader)
        {
            Leaderboard l = new Leaderboard()
            {
                Week = Convert.ToInt32(reader["week"]),
                TotalScore = Convert.ToInt32(reader["total_score"]),
                LeagueId = Convert.ToInt32(reader["league_id"]),
                UserId = Convert.ToInt32(reader["user_id"]),

            };

            return l;
        }
    }
}