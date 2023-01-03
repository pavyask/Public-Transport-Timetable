<script setup>
import Login from '../components/login/Login.vue'
import Logout from '../components/login/Logout.vue'
import axios from 'axios'
import { useStore } from 'vuex'


const store = useStore()

function loginRequest(login,password){
  axios.get(`${store.state.baseUrl}/users/${login}/${password}`)
    .then(response=>{
      console.log(response.data);
      if(response.data==null){
        store.commit('setWrongCredentials',true)
        alert(`Login or password is incorrect!\nPlease try again.`);
      }
      else{
        store.commit('setWrongCredentials',false)
        console.log(response.data)
        store.commit('login', response.data)
      }
    });
}

function logout(){
  store.commit('logout')
}
</script>

<template>
  <Login v-if="!$store.getters.isLoggedIn" @login="loginRequest"/>
  <Logout v-else="$store.getters.isLoggedIn" @logout="logout"/>
</template>