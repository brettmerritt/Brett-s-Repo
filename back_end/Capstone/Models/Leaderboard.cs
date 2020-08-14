using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Leaderboard
    {
        public int Week { get; set; }
        public int TotalScore { get; set; }
        public int LeagueId { get; set; }
        public int UserId { get; set; }
    }
}