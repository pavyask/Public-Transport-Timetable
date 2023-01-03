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
    axios.get(`https://localhost:7107/users/${store.getters.login}/stops`)
    .then(response=>{
        if(response.data==null){
            alert(`There is no data!`);
        } 
        else{
            savedStops.value = response.data;
            savedStops.value.forEach(stop => {
                timetables.value.push({
                    tableName: `${stop.name} ${stop.subName} [${stop.zoneName}]`,
                    requestString: `https://localhost:7107/stops/${stop.stopId}/timetable`,
                    stopId: stop.stopId
                })
            });
        }
    });
}

function removeStop(stopId){
  console.log("Removing works!")
  console.log(stopId);
  axios.delete(`https://localhost:7107/users/${store.getters.login}/stops/${stopId}`)
  location.reload()
}
</script>

<template>
    <h1>Saved stops</h1>
    <StopTimetable v-for="timetable in timetables" v-bind="timetable" @removeStop="removeStop"/>
</template>