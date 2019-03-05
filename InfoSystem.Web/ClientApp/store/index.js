import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const store = () =>
  new Vuex.Store({
    state: {
      weather: []
    },
    mutations: {
      setWeather(state, payload) {
        state.weather = payload
      }
    },
    actions: {
      async getWeather({ commit }) {
        let response = await axios.get('/api/SampleData/WeatherForecasts')
        commit('setWeather', response.data)
      }
    },
    getters: {
      weather(state) {
        return state.weather
      }
    }
  })

export default store
