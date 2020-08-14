<template>
<div class = "form">

<form action="/action_page.php">
  <label for="league">Enter the league ID of the league you are entering scores for: </label>
  <input type="text" id="league" name="league" v-model="newScores.leagueId"/>
  <br><br>
  <label for="date">Week:</label>
  <input type="text" id="week" name="week" v-model="newScores.week"/>
  <br><br>

  <label for="MatchScore">Match Score:</label>
  <input type="number" id="MatchScore" name="MatchScore" v-model="newScores.totalScore"/><br>
  <label for="date">Enter your user ID:</label>
  <input type="text" id="week" name="week" v-model="newScores.userId"/><br>
  <form action="/action_page.php">
  <p>Please upload an image for your scores to be validated.</p>
  <label for="img">Select image:</label>
  <input type="file" id="img" name="img" accept="image/*">
</form><br><br>
  <button class="btn btn-submit" v-on:click="createScore" >Submit</button>
</form>
</div>
</template>

<script>
import authService from '@/services/AuthService.js';

export default {
    data(){
        return{
            newScores: {
            week: '',
            totalScore: '',
            leagueId: '',
            userId: '',
        }
        }
    },
    methods: {
      createScore() {
      authService.postScores(this.newScores).then(response=>{
             alert(response.status + "Your score has been recorded successfully!")
            }
         )
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
</style>
