<script setup>
import { ref } from 'vue'
import axios from 'axios'

const props = defineProps({
    isLoggedIn: Boolean,
    username: String,
    password: String
  })
const emits = defineEmits(['login','logout'])

const usernameInput = ref(props.usernameInput)
const passwordInput = ref(props.passwordInput)

function loginRequest(username,password){
  axios.get(`https://localhost:7107/users/${username}/${password}`)
    .then(response=>{
      console.log(response.data);
      if(response.data==null){
        alert(`User or password is incorrect!\nPlease try again.`);
        usernameInput.value="";
        passwordInput.value="";
      }
      else
        emits(`login`,username,password);
    });
}

</script>

<template>
  <template v-if="!isLoggedIn">
    <h1>Please log in, to use the app</h1>
    <h1>Username: {{username}}, Password: {{password}}</h1>
    <button  @click="loginRequest(usernameInput,passwordInput)">Login</button>
    <input v-model="usernameInput" placeholder="Login...">
    <input v-model="passwordInput" placeholder="Password...">
  </template>

  <template v-else="isLoggedIn">
    <h1>Hello, {{ username }}</h1>
    <h1>Username: {{username}}, Password: {{password}}</h1>
    <button  @click="$emit('logout')">Logout</button>
  </template>
</template>