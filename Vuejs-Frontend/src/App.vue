<script setup>
import {ref} from 'vue'
import Login from './components/login/Login.vue'
import SavedStops from './components/stops/SavedStops.vue'
import AddNotSavedStops from './components/stops/AddNotSavedStops.vue'

// const props = ref({
//   isLoggedIn: false,
//   user:{
//     login : "",
//     password: "",
//     userStopIds:[]
//   }
// })

// function login(user){
//   console.log(user.login)
//   console.log(user.login.value)
//   console.log(user)
//   props.value = {
//     isLoggedIn: true,
//     user: user
//   };
//   console.log(props.value)
// }

// function logout(){
//   props.value = {
//     isLoggedIn: false,
//     user:{
//       login : "",
//       password: "",
//       userStopIds:[]
//     }
//   }
// }
</script>


<template>
  <header>
    <div id="nav">
    <router-link to="/">Home</router-link>
    <!-- <router-link to="/login" v-if="!$store.getters.isLoggedIn">Login</router-link>
    <router-link to="/logout" v-if="$store.getters.isLoggedIn">Logout</router-link> -->
    <router-link to="/savedStops" v-if="$store.getters.isLoggedIn">Saved Stops</router-link>
    <router-link to="/addStops" v-if="$store.getters.isLoggedIn">Add Stops</router-link>
  </div>
  <router-view/>
  </header>

</template>


<style scoped>

#nav {
  margin-bottom: 100px;
  padding: 30;
  text-align: center;
  /* background: #1abc9c; */
  color: white;
  font-size: 30px;
}
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>