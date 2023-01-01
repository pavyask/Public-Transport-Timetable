<script setup>
import { reactive,ref,onMounted,watchEffect  } from 'vue'

const props = defineProps({
    isLoggedIn: Boolean,
    username: String,
    password: String
  })
const emits = defineEmits(['login','logout'])

const usernameInput = ref(props.usernameInput)
const passwordInput = ref(props.passwordInput)
</script>

<template>
  <template v-if="!isLoggedIn">
    <h1>Please log in, to use the app</h1>
    <h1>Username: {{username}}, Password: {{password}}</h1>
    <button  @click="$emit('login',usernameInput ,passwordInput)">Login</button>
    <input v-model="usernameInput" placeholder="Login...">
    <input v-model="passwordInput" placeholder="Password...">
  </template>

  <template v-else="isLoggedIn">
    <h1>Hello, {{ username }}</h1>
    <h1>Username: {{username}}, Password: {{password}}</h1>
    <button  @click="$emit('logout')">Logout</button>
  </template>
</template>