<template>
  <div id="app">
      <div class background :style="{'background-image':'url(https://www.kcm-cg.com/wp-content/uploads/2013/01/Best-top-desktop-golf-wallpapers-hd-golf-wallpaper-sport-pictures-02.jpeg)'}">
  </div>
      <h1 class="img">
      <img class="logo" :src="'https://i.imgur.com/FGz32ZC.png' + img">
      </h1>
      <Navigation></Navigation> 
    <router-view />
  </div>  
</template>

<script>
import Navigation from './components/Navigation'

export default {
  name: 'App',
  components:{ 
    'Navigation': Navigation 
  }
}
</script>
<style>
@font-face {
  font-family: "Bree Serif";
  src: local("BreeSerif"),
   url(./fonts/BreeSerif-Regular.ttf) format("truetype");
}

.logo{
  justify-content: center;
  border: 6px solid;
  border-color: #1b3869;
}
.nav{
  display: flex;
  background-color: whitesmoke;
  font-family: "Bree Serif";
  font-size: 25px;
  justify-content:space-evenly;
  padding: 20px;
  width: 100%;
  border: 6px solid;
  border-color: #1b3869;
}
.background{
  width: 100%;
}
</style>
