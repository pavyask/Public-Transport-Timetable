<script setup>
import { useStore } from 'vuex'

const store = useStore()
const emits = defineEmits(['logout'])
</script>

<template>
    <h1>Hello, {{ $store.getters.login }}</h1>
    <button @click="$emit('logout')">Logout</button>
</template>
