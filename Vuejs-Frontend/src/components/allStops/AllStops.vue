<script setup>
  import axios from 'axios'
  import { ref ,onBeforeMount} from 'vue'

  const props = defineProps({
    isLoggedIn: Boolean,
    username: String,
    password: String
  })

  const stops = ref([]);

  const headers = ref([
      { text: "Name", value: "name" },
      { text: "Height (cm)", value: "height", sortable: true },
      { text: "Weight (kg)", value: "weight", sortable: true },
      { text: "Age", value: "age", sortable: true }
    ]);

    const items = ref([
      { "name": "Curry", "height": 178, "weight": 77, "age": 20 },
      { "name": "James", "height": 180, "weight": 75, "age": 21 },
      { "name": "Jordan", "height": 181, "weight": 73, "age": 22 }
    ]);

  onBeforeMount(() => {
    axios.get(`https://localhost:7107/stops`)
      .then(response=>{
        console.log(response);
        console.log(response.data);

        if(response.data==null){
          alert(`There is no data!`);
        }
        else{
          stops.value = response.data;
          console.log(stops.value);
          headers.value = Object.keys(stops.value[0]);
          values.value = stops.value;
        } 
      });
  });
</script>

<template>
  <h1>All Stops</h1>
  <EasyDataTable :headers="headers" :items="items"/>
</template>