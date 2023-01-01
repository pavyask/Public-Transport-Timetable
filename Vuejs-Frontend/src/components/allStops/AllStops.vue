<script setup>
  import axios from 'axios'
  import { ref, onBeforeMount, onMounted} from 'vue'

  const props = defineProps({
  isLoggedIn: Boolean,
    user:{
      login : String,
      password: String,
      savedStops: []
    }
})

  const stops = ref([]);
  const headers = ref([
    {text: "STOP ID", value: "stopId",sortable: true},
    { text: "NAME", value: "name"},
    { text: "SUB NAME", value: "subName"},
    { text: "ZONE NAME", value: "zoneName"},
  ]); 
  const items = ref([]);
  const itemsSelected = ref([ { "stopId": "8227", "name": "Dąbrowa Centrum", "subName": "04", "zoneName": "Gdynia", "users": [] } ]);
  console.log(props.user.savedStops);

  onBeforeMount(() => {
    axios.get(`https://localhost:7107/stops`)
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
  });

  onMounted(() => {
    axios.get(`https://localhost:7107/stops`)
  });
</script>

<template>
  <h1>All Stops</h1>
  <h1> Items Selected: {{itemsSelected}}</h1>
  <EasyDataTable v-model:items-selected="itemsSelected" :headers="headers" :items="items"/>
</template>