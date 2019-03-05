import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const store = () =>
  new Vuex.Store({
    state: {
      entities: [],
      currentValues: []
    },
    mutations: {
      setEntities(state, payload) {
        state.entities = payload
      },
      setCurrentValues(state, payload) {
        state.currentValues = payload
      }
    },
    actions: {
      async getEntities({ commit }, payload) {
        let response = await axios.get(`/Entity/GetByType?typeId=${payload}`)
        commit('setEntities', response.data)
      },
      async getValues({ commit }, payload) {
        let response = await axios.get(`/Value/GetByTypeId?entityId=${payload.entityId}&typeId=${payload.typeId}`)
        commit('setCurrentValues', response.data)
      }
    },
    getters: {
      entities(state) {
        return state.entities
      },
      currentValues(state) {
        return state.currentValues
      }
    }
  })

export default store
