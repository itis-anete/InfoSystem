import axios from 'axios'

export default {
  state: {
    token: '',
    login: ''
  },
  mutations: {
    setToken(state, payload) {
      state.token = payload
    },
    setLogin(state, payload) {
      state.login = payload
    }
  },
  actions: {
    async authenticate({ commit }, payload) {
      let response = await axios.get(`/api/User/LogIn?login=${payload.login}&password=${payload.password}`)
      window.localStorage['login'] = response.data.login
      commit('setLogin', response.data.login)
      window.localStorage['token'] = response.data.token
      commit('setToken', response.data.token)
    },
    async register({ dispatch }, payload) {
      await axios.post(`/api/User/Register?login=${payload.login}&password=${payload.password}`)
      dispatch('getTokenAndLogin', payload)
    },
    async logOut({ commit }) {
      delete window.localStorage['login']
      delete window.localStorage['token']
      commit('setLogin', '')
      commit('setToken', '')
    }
  }
}
