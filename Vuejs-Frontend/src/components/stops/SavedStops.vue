<script setup>
import { ref, onBeforeMount} from 'vue'
import axios from 'axios'
import StopTimeTable from './StopTimetable.vue'

const props = defineProps({
isLoggedIn: Boolean,
user:{
    login : String,
    password: String,
    userStopIds: []
}
})


const savedStops = ref([])
const timetables = ref([])

onBeforeMount(() => {
  getSavedStops()
});

function getSavedStops(){
    axios.get(`https://localhost:7107/users/${props.user.login}/stops`)
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
  axios.delete(`https://localhost:7107/users/${props.user.login}/stops/${stopId}`)
}
</script>

<template>
    <h1>Saved stops</h1>
    <StopTimeTable v-for="timetable in timetables" v-bind="timetable" @removeStop="removeStop"/>
</template>