<script setup>
import { ref } from 'vue'
import axios from 'axios'
import { useStore } from 'vuex'

const store = useStore()
const loginInput = ref("")
const passwordInput = ref("")

function loginRequest(login,password){
  axios.get(`https://localhost:7107/users/${login}/${password}`)
    .then(response=>{
      console.log(response.data);
      if(response.data==null){
        alert(`Login or password is incorrect!\nPlease try again.`);
      }
      else{
        console.log(response.data)
        store.commit('login', response.data)  
      }
    });
}
</script>

<template>
  <div v-if="!$store.getters.isLoggedIn">
    <h1>Please log in, to use the app</h1>
    <button  @click="loginRequest(loginInput,passwordInput)">Login</button>
    <input v-model="loginInput" placeholder="Login...">
    <input v-model="passwordInput" placeholder="Password...">
  </div>

  <div v-else="$store.getters.isLoggedIn">
    <h1>Hello, {{ $store.getters.login }}</h1>
    <button @click="$store.commit('logout')">Logout</button>
  </div>
</template>