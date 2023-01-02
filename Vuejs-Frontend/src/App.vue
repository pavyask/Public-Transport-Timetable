<script setup>
  import {ref} from 'vue'

  import Login from './components/login/Login.vue'
  import SavedStops from './components/stops/SavedStops.vue'
  import AllNotSavedStops from './components/stops/AllNotSavedStops.vue'
  
  
  const props = ref({
    isLoggedIn: false,
    user:{
      login : "",
      password: "",
      userStopIds:[]
    }
  })

  function login(user){
    console.log(user)
    props.value = {
      isLoggedIn: true,
      user: user
    };
    console.log(props.value)
  }

  function logout(){
    props.value = {
      isLoggedIn: false,
      user:{
        login : "",
        password: "",
        userStopIds:[]
      }
    }
  }
</script>


<template>
<header>
    <Login v-bind="props" @logout="logout" @login="login"/>
  </header>

  <main>
    <!-- <SavedStops v-bind="props" v-if="props.isLoggedIn"/> -->
    <AllNotSavedStops v-bind="props" v-if="props.isLoggedIn"/>
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
