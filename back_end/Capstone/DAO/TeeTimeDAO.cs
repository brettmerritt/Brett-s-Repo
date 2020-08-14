using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class TeeTimeDAO : ITeeTimeDAO
    {
        private readonly string connectionString;
        private string SqlQueryTeeTime = @"SELECT * FROM TeeTimes WHERE from_date < @departureDate AND to_date > @arrivalDate";

        public TeeTimeDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }
        public IList<TeeTime> GetAvailableTeeTimes(int courseId, DateTime arrivalDate, DateTime departureDate)
        {
            List<TeeTime> teeTimes = new List<TeeTime>();


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(SqlQueryTeeTime, connection);
                    cmd.Parameters.AddWithValue("@courseId", courseId);
                    cmd.Parameters.AddWithValue("@arrivalDate", arrivalDate.ToShortDateString());
                    cmd.Parameters.AddWithValue("@departureDate", departureDate.ToShortDateString());

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TeeTime teeTime = ConvertReaderToTeeTime(reader);
                        teeTimes.Add(teeTime);
                    }
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine("There has been an error");
            }
            return teeTimes;
        }

        private TeeTime ConvertReaderToTeeTime(SqlDataReader reader)
        {
            TeeTime teeTime = new TeeTime();
            teeTime.Id = Convert.ToInt32(reader["teeTimeId"]);

            return teeTime;
        }
    }
}
