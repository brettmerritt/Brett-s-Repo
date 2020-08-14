<template>
    <div class="form">
      <form>
        <label for="Course Name">Course Name:</label><br>
        <input type="text" id="courseName" name="courseName" v-model="newCourse.courseName"/><br><br>
        <label>Number of Holes:</label>
        <input type="number" v-model="newCourse.holes"/><br><br>
        <label>Address:</label>
        <input type="text" v-model="newCourse.address"/><br><br>
        <button class="btn btn-submit" v-on:click="createCourse" >Submit</button>
      </form><br>
    </div>
</template>

<script>
import authService from '@/services/AuthService.js';

export default {

  data(){
      return{
          newCourse :{
          courseName: '',
          holes: '',
          address: '',
          }
      }
  },
    methods: {

      createCourse() {
      authService.createCourse(this.newCourse).then(response=>{
             alert("Your course has been created successfully!")
            }
         ).catch(error => {alert("Error")})
      }
    }
}
</script>