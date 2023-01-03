import { createStore } from 'vuex'
import cookies from 'js-cookie'

export default createStore({
  state: {
    // cookies: cookies,

    // isLoggedIn: false,
    // login:"",
    // password: "",

    // userStopIds:[]e
  },

  getters: {
    isLoggedIn(state,getters){
      console.log("isLoggedIn...")
      let isLoggedIn = cookies.get('isLoggedIn')
      if(isLoggedIn == "true"){
        return true
      }
      else{
        return false
      }
    },

    login (state,getters) {
      console.log("login...")
      let login = cookies.get('login')
      if(login==undefined)
        return ""
      else
        return login
    },

    password (state,getters) {
      console.log("password...")
      let password = cookies.get('password')
      if(password==undefined)
        return ""
      else
        return password
    },
  },

  mutations:{
    // initState(state,getters){
    //   state.userStopIds=
    //   state.isLoggedIn=true
    //   state.login=user.login
    //   state.password=user.password
    // },

    login(state,user){
      console.log("login mutation...")
      // state.userStopIds=user.userStopIds
      // state.isLoggedIn=true
      // state.login=user.login
      // state.password=user.password

      // console.log(`Before login`)
      // console.log(`Cookies login: ${cookies.get('login')}`)
      // console.log(`Cookies password: ${cookies.get('password')}`)
      // console.log(`Cookies isLoggedIn: ${cookies.get('isLoggedIn')}`)
      // console.log(`Getter login: ${getters.login}`)
      // console.log(`Getter password: ${getters.password}`)
      // console.log(`Getter isLoggedIn: ${getters.isLoggedIn}`)

      cookies.set('login',user.login)
      cookies.set('password',user.password)
      cookies.set('isLoggedIn',true)
      location.reload()

      // console.log(`After login`)
      // console.log(`Cookies login: ${cookies.get('login')}`)
      // console.log(`Cookies password: ${cookies.get('password')}`)
      // console.log(`Cookies isLoggedIn: ${cookies.get('isLoggedIn')}`)
      // console.log(`Getter login: ${getters.login}`)
      // console.log(`Getter password: ${getters.password}`)
      // console.log(`Getter isLoggedIn: ${getters.isLoggedIn}`)
    },
    
    logout(state,getters){
      console.log("logout mutation...")
      // state.isLoggedIn=false
      // state.login=""
      // state.password=""
      // state.userStopIds=[]

      // console.log(`Cookies login: ${cookies.get('login')}`)
      // console.log(`Cookies password: ${cookies.get('password')}`)
      // console.log(`Cookies isLoggedIn: ${cookies.get('isLoggedIn')}`)

      cookies.set('login','')
      cookies.set('password','')
      cookies.set('isLoggedIn',false)
      location.reload()

      //       console.log(`Cookies login: ${cookies.get('login')}`)
      // console.log(`Cookies password: ${cookies.get('password')}`)
      // console.log(`Cookies isLoggedIn: ${cookies.get('isLoggedIn')}`)
    }
  }
})