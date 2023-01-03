<script setup>
import axios from 'axios'
import { ref, onBeforeMount} from 'vue'

const props = defineProps({
  // tableName: String,
  requestString: String,
  // button:{
  //     content: String,
  //     actionName: String
  // }
})

const emits = defineEmits(['saveStops'])

const stops = ref([]);

const headers = ref([
  {text: "STOP ID", value: "stopId",sortable: true},
  { text: "NAME", value: "name"},
  { text: "SUB NAME", value: "subName"},
  { text: "ZONE NAME", value: "zoneName"},
]); 
const items = ref([]);
const itemsSelected = ref([]);

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
          stops.value = response.data;
          stops.value.forEach(element => {
              items.value.push(element)
          });
      }
    });
    // console.log(props.button.actionName)
}
</script>

<template>
  <h1>Add not saved stops</h1>
  <!-- <h1> Items Selected: {{itemsSelected}}</h1> -->
  <button @click="$emit('saveStops', itemsSelected)">Save stops</button>
  <EasyDataTable v-model:items-selected="itemsSelected" :headers="headers" :items="items"/>
</template>