import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import store from './store/store.js'
import router from './router/router.js'
import Vue3EasyDataTable from 'vue3-easy-data-table'
import 'vue3-easy-data-table/dist/style.css'


const app = createApp(App)
app.use(store)
app.use(router)
app.component('EasyDataTable', Vue3EasyDataTable)
app.mount('#app')