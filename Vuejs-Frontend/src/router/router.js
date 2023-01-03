import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import SavedStops from '../views/SavedStops.vue'
import AddStops from '../views/AddStops.vue'

const routes = [
    {
        path: '/',
        name: 'Home',
        component: Home
    },
    {
        path: '/savedStops',
        name: 'SavedStops',
        component: SavedStops
    },
    {
        path: '/addStops',
        name: 'AddStops',
        component: AddStops
    },
]

const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router