<template>
  <div class="form">
      <h3>Select a league to join: </h3><br><br>
      <form>
      <label>League ID you want to join:</label>
<input type="number" v-model="newJoin.leagueId"/><br><br>
<label>Your user ID:</label>
<input type="number" v-model="newJoin.userId"/><br><br>
<button class="btnbtn-submit" v-on:click.native="joinLeague">Submit</button>  <br>
    <div class = "leagues">
        <table><div class="league"
        v-for="league in League"
        v-bind:key="league">
        <tr>
<th>{{league.leagueName}}-</th>
<th>{{league.leagueId}}</th>
</tr>
        </div>
        </table>
        </div>
      
        </form>
        
  </div>

</template>

<script>
import authService from '@/services/AuthService.js';


export default {
    name: 'League',
    components:
    {
        
    },
data(){
    return{
        newJoin: {
            leagueId: '',
            userId: ''
    },
            League: [],
            leagueId: '',
            leagueName: '',
            leagueAdmin: '',
            courseId: '',
            startDate: '',
            endDate: '',
            scoreLeague: '',
    }
},
created(){

     authService.Leagues().then((response) => {
              this.League = response.data;
          })
},
methods:{
joinLeague() {
      authService.joinLeague(this.newJoin).then(response=>{
             alert("Your course has been created successfully!")
            }
         ).catch(error => {alert("Error")})
      }
      
}

}
</script>

<style>
.form{
    display: flex;
    justify-content: center;
  font-family: 'Copperplate';
  color: #2d487a;
  font-size: 30px; 
  height: 100%; 
  background-color: whitesmoke;

}
.league{
    display: grid;
    justify-content: space-evenly;
    color: #2d487a;
    font-size: 25px;
    
  font-family: 'Copperplate';


}
.btnbtn-submit{
    display: flex;
    justify-content: center;
}
</style>