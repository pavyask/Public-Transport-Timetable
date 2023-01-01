<script setup>
import { ref } from 'vue'
import axios from 'axios'

const props = defineProps({
  isLoggedIn: Boolean,
  user:{
    login : String,
    password: String,
    savedStops: []
  }
})
const emits = defineEmits(['login','logout'])

const loginInput = ref("")
const passwordInput = ref("")

function loginRequest(login,password){
  axios.get(`https://localhost:7107/users/${login}/${password}`)
    .then(response=>{
      console.log(response.data);
      if(response.data==null){
        alert(`Login or password is incorrect!\nPlease try again.`);
        loginInput.value="";
        passwordInput.value="";
      }
      else{
        loginInput.value="";
        passwordInput.value = "";
        emits(`login`,response.data);
      }
    });
}

</script>

<template>
  <template v-if="!isLoggedIn">
    <h1>Please log in, to use the app</h1>
    <h1>Login: {{user.login}}, Password: {{user.password}}</h1>
    <button  @click="loginRequest(loginInput,passwordInput)">Login</button>
    <input v-model="loginInput" placeholder="Login...">
    <input v-model="passwordInput" placeholder="Password...">
  </template>

  <template v-else="isLoggedIn">
    <h1>Hello, {{ user.login }}</h1>
    <h1>Login: {{user.login}}, Password: {{user.password}}</h1>
    <button  @click="$emit('logout')">Logout</button>
  </template>
</template>