<script setup>
import { ref} from 'vue'
import axios from 'axios'
import StopsTable from './StopsTable.vue'


const props = defineProps({
  isLoggedIn: Boolean,
  user:{
    login : String,
    password: String,
    userStopIds: []
  }
})

const tableProps = ref({
    // tableName: "Add not saved stops",
    requestString: `https://localhost:7107/users/${props.user.login}/stops/not-saved`,
    // button:{
    //     content: "Save stops",
    //     actionName: saveStops.name
    // }
})


function saveStops(stops){
  console.log("Saving works!")
  console.log(stops);
  let stopIds = stops.map(s => s.stopId);
  console.log(stopIds);
  axios.post(`https://localhost:7107/users/${props.user.login}/stops`, stopIds)
}
</script>

<template>
  <StopsTable v-bind="tableProps" @saveStops="saveStops"/>
</template>