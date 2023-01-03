import { createStore } from 'vuex'
import cookies from 'js-cookie'

export default createStore({
  state: {
    areStopsUpdating: false,
    wrongCredentials:false,
    baseUrl: `https://localhost:7107`
  },

  getters: {
    isLoggedIn(state,getters){
      let isLoggedIn = cookies.get('isLoggedIn')
      if(isLoggedIn == "true"){
        return true
      }
      else{
        return false
      }
    },

    login (state,getters) {
      let login = cookies.get('login')
      if(login==undefined)
        return ""
      else
        return login
    },

    password (state,getters) {
      let password = cookies.get('password')
      if(password==undefined)
        return ""
      else
        return password
    },
  },

  mutations:{
    setAreStopsUpdating(state,value){
      state.areStopsUpdating=value
    },

    setWrongCredentials(state,value){
      state.wrongCredentials=value
    },

    login(state,user){
      cookies.set('login',user.login)
      cookies.set('password',user.password)
      cookies.set('isLoggedIn',true)
      location.reload()
    },
    
    logout(state,getters){
      cookies.set('login','')
      cookies.set('password','')
      cookies.set('isLoggedIn',false)
      location.reload()
    }
  }
})