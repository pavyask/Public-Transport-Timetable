<script setup>
import { ref} from 'vue'
import { useStore } from 'vuex'
import axios from 'axios'
import StopsTable from '../components/stops/StopsTable.vue'

const store = useStore()
const tableProps = ref({
    requestString: `https://localhost:7107/users/${store.getters.login}/stops/not-saved`,
})


function saveStops(stops){
  console.log("Saving works!")
  console.log(stops);
  let stopIds = stops.map(s => s.stopId);
  console.log(stopIds);
  axios.post(`https://localhost:7107/users/${store.getters.login}/stops`, stopIds)
  location.reload()
}

function updateAllStops(){
  axios.get(`https://localhost:7107/stops`)
  .then((response)=>{
    location.reload()
    alert("Stops data updated succesfully")
  })
}
</script>

<template>
  <h1>Update stops data from ZTM API</h1>
  <button @click="updateAllStops">Update all stops</button>
  <StopsTable v-bind="tableProps" @saveStops="saveStops"/>
</template>