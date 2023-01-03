<script setup>
import { ref} from 'vue'
import { useStore } from 'vuex'
import axios from 'axios'
import StopsTable from '../components/stops/StopsTable.vue'
import UpdateAllStops from '../components/stops/UpdateAllStops.vue';

const store = useStore()
const tableProps = ref({
    requestString: `${store.state.baseUrl}/users/${store.getters.login}/stops/not-saved`,
})


function saveStops(stops){
  console.log("Saving works!")
  console.log(stops);
  let stopIds = stops.map(s => s.stopId);
  console.log(stopIds);
  axios.post(`${store.state.baseUrl}/users/${store.getters.login}/stops`, stopIds)
  location.reload()
}
</script>

<template>
  <UpdateAllStops/>
  <StopsTable v-bind="tableProps" @saveStops="saveStops"/>
</template>