<template>
    <div class = "form">
        <form>
    <label for="League Name">League Name:</label><br>
  <input type="text" id="LeagueName" name="LeagueName" v-model="newLeague.leagueName"/><br><br>

    <label for="Admin Username">Admin Username:</label><br>
  <input type="text"  id="AdminUsername" name="AdminUsername" v-model="newLeague.leagueAdmin"/><br><br>

<!-- 
  <label for="course">Choose a Course:</label>
  <select name="Courses" id="courses">
    <option value="Course1">Course 1</option>
    <option value="Course2">Course 2</option>
    <option value="Course3">Course 3</option>
    <option value="Course4">Course 4</option>
  </select><br><br> -->

    <label for="CourseID">Course ID:</label><br>
  <input type="number" id="CourseID" name="CourseID" v-model="newLeague.courseID"/><br><br>

  
  <label for="date">Match Start Date:</label><br>

<input type="date"  id="startdate" name="match-start-date"
       value="2020-06-08"
       min="2020-08-06" max="2019-8-6" v-model="newLeague.startDate"/><br><br> 

 <label for="date">Match End Date:</label><br>

<input type="date" id="date" name="match-date"
       value="2020-06-08"
       min="2020-08-06" max="2019-8-6" v-model="newLeague.endDate"/><br><br>

<label for="Score League">Is this a score league? </label>
<input type="checkbox" checked="true" v-model="newLeague.scoreLeague" /><br><br>


   <button class="btn btn-submit" v-on:click="createLeague">Submit</button>

        </form><br>
        <div class = "map">
          
        <Map/>
        </div>
    </div>
</template>

<script>

import Map from '@/views/Map';
import authService from '@/services/AuthService.js';

export default {
  name: 'Home',
  components:{
    Map
  },
  data(){
      return{
          newLeague:{
          leagueName: '',
          leagueAdmin: '',
          courseID: '',
          startDate: '',
          endDate: '',
          scoreLeague: '',
          }
      }
  },
     methods: {
      // submitForm() {
      //  const newLeague = {
      //      leagueName: this.league.leagueName,
      //      leagueAdmin: this.league.leagueAdmin,
      //      courseID: this.league.courseID,
      //      startDate: this.league.startDate,
      //      endDate: this.league.endDate,
      //      scoreLeague: this.league.scoreLeague,
      //    }},

        createLeague() {
        authService.createLeague(this.newLeague).then(response =>{
               alert(response.status + "Your league has been created successfully!")
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
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  background-color: white;

}
.map{
    display: flex;
    justify-content: center;
}
</style>