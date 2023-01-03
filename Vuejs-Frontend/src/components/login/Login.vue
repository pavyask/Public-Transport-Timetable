<script setup>
import { ref } from 'vue'
import { useStore } from 'vuex';

const store = useStore();
const emits = defineEmits(['login'])
const loginInput = ref("")
const passwordInput = ref("")
</script>

<template v-if="!$store.getters.isLoggedIn">
  <h1>Please log in, to use the app</h1>
  <button @click="$emit('login', loginInput, passwordInput)">Login</button>

  <input v-model="loginInput" placeholder="Login..." 
  :class="{wrongCredentials:$store.state.wrongCredentials}">
  
  <input v-model="passwordInput" placeholder="Password..." 
  :class="{wrongCredentials:$store.state.wrongCredentials}">
</template>


<style scope>
.wrongCredentials{
  border: 2px solid red;
  border-radius: 2px;
}
</style>