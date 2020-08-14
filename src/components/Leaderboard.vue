<template>
<div>
    <table class = "table">
            <tr>
        <th>League </th>
        <th>User ID </th>
        <th>Week </th>
        <th>Score </th>
      </tr>
      <tr>
        <th>{{League[0].leagueName}}</th>
        <th>{{Leaderboard[0].userId}}</th>
        <th>{{Leaderboard[0].week}}</th>
        <th>{{Leaderboard[0].totalScore}}</th>
      </tr>
      <tr>
        <th> </th>
        <th>{{Leaderboard[1].userId}}</th>
        <th>{{Leaderboard[1].week}}</th>
        <th>{{Leaderboard[1].totalScore}}</th>
      </tr>
      <tr>
        <th> </th>
        <th>{{Leaderboard[2].userId}}</th>
        <th>{{Leaderboard[2].week}}</th>
        <th>{{Leaderboard[2].totalScore}}</th>
      </tr>
           <tr>
        <th> </th>
        <th>{{Leaderboard[4].userId}}</th>
        <th>{{Leaderboard[4].week}}</th>
        <th>{{Leaderboard[4].totalScore}}</th>
      </tr>
            <tr>
        <th> {{League[3].leagueName}}</th>
        <th>{{Leaderboard[3].userId}}</th>
        <th>{{Leaderboard[3].week}}</th>
        <th>{{Leaderboard[3].totalScore}}</th>
      </tr>
            <!-- <tr>
        <th> {{League[5].leagueName}}</th>
        <th>{{Leaderboard[5].userId}}</th>
        <th>{{Leaderboard[5].week}}</th>
        <th>{{Leaderboard[5].totalScore}}</th>
      </tr> -->
                  <!-- <tr>
        <th> {{League[6].leagueName}}</th>
        <th>{{Leaderboard[6].userId}}</th>
        <th>{{Leaderboard[6].week}}</th>
        <th>{{Leaderboard[6].totalScore}}</th>
      </tr>
                  <tr>
        <th> {{League[7].leagueName}}</th>
        <th>{{Leaderboard[7].userId}}</th>
        <th>{{Leaderboard[7].week}}</th>
        <th>{{Leaderboard[7].totalScore}}</th>
      </tr> -->

</table>
    </div>
</template>

<script>
import authService from '@/services/AuthService.js'

export default {
    data()
   {
     return {
       Leaderboard: [],
       week: '',
       totalScore: '',
       leagueId: '',
       userId: '',
        
         League: [],
             leagueName: '',
             leagueAdmin: '',
             courseId: '',
             startDate: '',
             endDate: '',
            scoreLeague: '',
            Users: [],
              username: '',
              passwordHash: '',
              salt: '',
              userRole: ''
   }
     },
     created(){
       authService.getLeaderboard().then((response) => {
              this.Leaderboard = response.data;
     }),
     authService.Leagues().then((response) => {
              this.League = response.data;
          }),
          authService.getUser(this.$route.params.id).then((response) => {
              this.Users = response.data;
          });   
              
     }
      
      
}
</script>
<style>
.table{
  padding: 20px;
}
</style>