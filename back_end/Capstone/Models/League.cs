using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class League
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public string LeagueAdmin { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool ScoreLeague { get; set; }

        public League()
        {

        }
        public League(int leagueId, string leagueName, string leagueAdmin, int courseId, DateTime startDate, DateTime endDate, bool scoreLeague)
        {

            LeagueId = leagueId;
            LeagueName = leagueName;
            LeagueAdmin = leagueAdmin;
            CourseId = courseId;
            StartDate = startDate;
            EndDate = endDate;
            ScoreLeague = scoreLeague;
        }
    }
}