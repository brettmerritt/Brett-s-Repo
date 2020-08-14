using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private static ILeagueDAO leagueDAO;
        private static ILeaderboardDAO leaderboardDAO;
        private static IUserDAO userDAO;
        private static ILeagueUserDAO leagueUserDAO;
        private static ICourseDAO courseDAO;


        public UserController(ILeagueDAO _leagueDAO, ILeaderboardDAO _leaderboardDAO, IUserDAO _userDAO, ILeagueUserDAO _leagueUserDAO, ICourseDAO _courseDAO)
        {
            leagueDAO = _leagueDAO;
            leaderboardDAO = _leaderboardDAO;
            userDAO = _userDAO;
            leagueUserDAO = _leagueUserDAO;
            courseDAO = _courseDAO;
        }

        [HttpGet("/leagues/{username}")]
        public List<League> ListLeaguesByUser(string username)
        {
            List<League> league = new List<League>();
            league = leagueDAO.ListLeaguesByUser(username);
            return league;
        }



        [HttpPost("/create")]
        public ActionResult<League> NewLeague(League league)
        {
            League leagueAdded = leagueDAO.AddLeague(league);
            return Ok();

        }

        [HttpGet("/league")]
        public List<League> GetAllLeagues()
        {
            List<League> league = new List<League>();
            league = leagueDAO.GetAllLeagues();
            return league;
        }

        [HttpGet("/leaderboard")]
        public List<Leaderboard> GetAllScores()
        {
            List<Leaderboard> leaderboard = new List<Leaderboard>();
            leaderboard = leaderboardDAO.GetAllScores();
            return leaderboard;
        }
        [HttpPost("/post")]
        public ActionResult<Leaderboard> NewScore(Leaderboard score)
        {
          Leaderboard scoreAdded = leaderboardDAO.AddScore(score);
            return Ok();

        }
        [HttpGet("/user/{leagueId}")]
        public List<User> GetUserByLeague(int leagueId)
        {
            List<User> user = new List<User>();
            user = userDAO.GetUsersByLeague(leagueId);
            return user;
        }

        [HttpPost("/join")]
        public ActionResult<LeagueUser> JoinLeague(LeagueUser league)
        {
            LeagueUser userJoined = leagueUserDAO.JoinLeague(league);
            return Ok();
        }

        [HttpPost("/new")]
        public ActionResult<Course> NewCourse(Course course)
        {
            Course courseAdded = courseDAO.AddCourse(course);
            return Ok();

        }

        [HttpGet("/leagueusers")]
        public List<LeagueUser> GetLeagueUsers()
        {
            List<LeagueUser> leagueUsers = new List<LeagueUser>();
            leagueUsers = leagueUserDAO.GetLeagueUsers();
            return leagueUsers;
        }
    }
}

