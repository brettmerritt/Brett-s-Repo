<template>
  <div>
      <h1>{{Users[0].userId}}</h1>
      <h2>{{League[1].leagueName}}</h2>
  </div>
</template>

<script>
import authService from '@/services/AuthService.js'

export default {
    data(){
        return{
             League: [],
            leagueId: '',
            leagueName: '',
            leagueAdmin: '',
            courseId: '',
            startDate: '',
            endDate: '',
            scoreLeague: '',
            Users: [],
              userId: '',
              username: '',
              passwordHash: '',
              salt: '',
              userRole: ''
        }
    },
    created(){
        authService.getUser(this.$route.params.id).then((response) => {
              this.Users = response.data;
          });   
        authService.getLeagueByUserId(this.$route.params.id).then((response) => {
            this.League = response.data;
        })
    }
}
</script>

<style>

</style>