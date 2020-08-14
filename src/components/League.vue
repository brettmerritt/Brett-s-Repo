<template>
<div class = "League">
        <!-- <div class="league"
        v-for="league in League"
        v-bind:key="league">
       <h1>{{league.leagueName}}</h1>
      
    </div> -->
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
          authService.getLeaguesByUserId(this.$route.params.id).then((response) => {
              this.League = response.data;
          }),
            authService.getUser(this.$route.params.id).then((response) => {
              this.Users = response.data;
          }),
          authService.Leagues().then((response) => {
              this.Leagues = response.data;
          })
    }

}
</script>