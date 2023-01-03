<script setup>
import axios from 'axios'
import { useStore } from 'vuex'

const store = useStore()

function updateAllStops(){
  store.commit('setAreStopsUpdating',true)
  axios.get(`${store.state.baseUrl}/stops`)
  .then(()=>{
    store.commit('setAreStopsUpdating',false)
    location.reload()
    alert("Stops data updated succesfully")
  })
}
</script>

<template>
  <h1>Update stops data from ZTM API</h1>
  <button @click="updateAllStops"
  :disabled="$store.state.areStopsUpdating"
  :class="{ active: !$store.state.areStopsUpdating, inactive: $store.state.areStopsUpdating}">Update all stops</button>
</template>


<style scoped>
.active {
  background-color: rgb(42, 252, 0);
}

.inactive {
  color: white;
 background-color: rgb(255, 0, 0);
}
</style>