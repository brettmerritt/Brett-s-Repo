using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ILeagueDAO
    {
        League GetLeague(string leagueName);
        List<League> ListLeaguesByUser(string username);
        League AddLeague(League league);
        List<League> GetAllLeagues();

    }
}