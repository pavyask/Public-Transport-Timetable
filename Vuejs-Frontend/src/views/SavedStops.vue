<script setup>
import { ref, onBeforeMount} from 'vue'
import { useStore } from 'vuex'
import axios from 'axios'
import StopTimetable from '../components/stops/StopTimetable.vue'

const store = useStore()
const savedStops = ref([])
const timetables = ref([])

onBeforeMount(() => {
  getSavedStops()
});

function getSavedStops(){
    axios.get(`${store.state.baseUrl}/users/${store.getters.login}/stops`)
    .then(response=>{
        if(response.data==null){
            alert(`There is no data!`);
        } 
        else{
            savedStops.value = response.data;
            savedStops.value.forEach(stop => {
                timetables.value.push({
                    tableName: `[${stop.stopId}] ${stop.name} ${stop.subName}, ${stop.zoneName}`,
                    requestString: `${store.state.baseUrl}/stops/${stop.stopId}/timetable`,
                    stopId: stop.stopId
                })
            });
        }
    });
}

function removeStop(stopId){
  console.log("Removing works!")
  console.log(stopId);
  axios.delete(`${store.state.baseUrl}/users/${store.getters.login}/stops/${stopId}`)
  location.reload()
}
</script>

<template>
    <h1>Saved stops</h1>
    <StopTimetable v-for="timetable in timetables" v-bind="timetable" @removeStop="removeStop"/>
</template>