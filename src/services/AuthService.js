import axios from 'axios';

const http = axios.create({
  baseURL: "https://localhost:44315"
});

export default {
  getLeaderboard(){
    return axios.get('/leaderboard')
  },

  login(user) {
    return axios.post('/login', user)
  },

  register(user) {
    return axios.post('/register', user)
  },

  Leagues(){
    return http.get('/league');
  },

  getUser(id){
    return http.get(`/user/${id}`)
  },
   getLeaguesByUserId(username){
     return http.get(`/league/${username}`)
   },
  getLeagueByLeagueID(id){
    return http.get(`/leagues/${id}`, id)
  },
  createLeague(newLeague){
    return http.post('/create', newLeague)
  },
  postScores(newScore){
    return http.post('/post', newScore)
  },
  createCourse(newCourse){
    return http.post('/new', newCourse)
  },
  joinLeague(newJoin){
    return http.post('/join', newJoin)
  }




  
}
