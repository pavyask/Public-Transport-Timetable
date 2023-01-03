<script setup>
import { useStore } from 'vuex'

const store = useStore()
</script>

<template>
    <header>
        <div id="nav">
            <router-link to="/">Home</router-link>
            <router-link to="/savedStops" v-if="$store.getters.isLoggedIn">Saved Stops</router-link>
            <router-link to="/addStops" v-if="$store.getters.isLoggedIn">Add Stops</router-link>
        </div>
    </header>
</template>

<style scoped>
#nav {
  margin-bottom: 100px;
  padding: 40px;
  text-align: center;
  font-size: 30px;
}
</style>