<script setup>
import axios from 'axios'
import { ref, onBeforeMount} from 'vue'
import { useStore } from 'vuex'

const store = useStore()

const props = defineProps({
  requestString: String,
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
}
</script>

<template>
  <h1>Add not saved stops</h1>
  <button @click="$emit('saveStops', itemsSelected)">Save stops</button>
  <EasyDataTable v-model:items-selected="itemsSelected" :headers="headers" :items="items"/>
</template>