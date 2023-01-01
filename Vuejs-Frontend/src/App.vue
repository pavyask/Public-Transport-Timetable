<script setup>
  import {ref} from 'vue'

  import Login from './components/login/Login.vue'
  import SavedStops from './components/savedStops/SavedStops.vue'
  import AllStops from './components/allStops/AllStops.vue'
  
  
  const props = ref({
    isLoggedIn: false,
    username : "",
    password: ""
  })

  function login(username, password){
    props.value = {
      isLoggedIn: true,
      username: username,
      password: password
    };
  }

  function logout(){
    props.value = {
      isLoggedIn: false,
      username: "",
      password: ""
    }
  }
</script>


<template>
<header>
    <Login v-bind="props" @logout="logout" @login="login"/>
  </header>

  <main>
    <SavedStops v-bind="props" v-if="props.isLoggedIn"/>
    <AllStops v-bind="props" />
  </main>
</template>


<style scoped>
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
