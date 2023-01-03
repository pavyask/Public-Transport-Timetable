<script setup>
import axios from 'axios'
import { ref, onBeforeMount} from 'vue'
import { useStore } from 'vuex'

const store = useStore()

const props = defineProps({
  tableName: String,
  requestString: String,
  stopId: String
})

const emits = defineEmits(['removeStop'])

const headers = ref([
  {text: "ROUTE", value: "routeId"},
  { text: "DIRECTION", value: "headSign"},
  { text: "DEPARTURE", value: "estimatedTime"},
]);
const items = ref([]);
const timetable = ref([]);
const lastUpdate = ref();

onBeforeMount(() => {
  getStopsForTable(props.requestString)
});

function getStopsForTable(requestString){
  axios.get(requestString)
  .then(response=>{
      if(response.data==null){
          alert(`There is no data!`);
      }
      else{
        console.log(response.data.stopTimetableItems)

        lastUpdate.value = response.data.lastUpdate;
        timetable.value = response.data.stopTimetableItems;

        timetable.value.forEach(element => {
            items.value.push({
                routeId: element.routeId,
                headSign: element.headSign,
                estimatedTime: element.estimatedTime
            })
        });
      }
    });
}
</script>


<template>
  <h1>{{ props.tableName }} | Last update: {{ lastUpdate }}</h1>
  <button @click="$emit('removeStop',props.stopId)">Remove stop</button>
  <EasyDataTable :headers="headers" :items="items"/>
</template>