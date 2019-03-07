import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const store = () =>
  new Vuex.Store({
    state: {
      entities: null,
      currentValues: null,
      attributes: null
    },
    mutations: {
      setEntities(state, payload) {
        state.entities = payload
      },
      setCurrentValues(state, payload) {
        state.currentValues = payload
      },
      editCurrentValues(state, payload) {
        var current = state.currentValues
        var index = current.findIndex(x => x.id == payload.id)
        current.splice(index, 1, payload)
      },
      setAttributes(state, payload) {
        state.attributes = payload
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
      },
      async getAttributes({ commit }, payload) {
        let response = await axios.get(`/Attribute/GetByTypeId?typeId=${payload}`)
        commit('setAttributes', response.data)
      },
      async editValue({ commit }, payload) {
        let response = await axios.put('/Value/EditValue', payload)
        commit('editCurrentValues', response.data)
      }
    },
    getters: {
      entities(state) {
        return state.entities
      },
      currentValues(state) {
        return state.currentValues
      },
      attributes(state) {
        return state.attributes
      }
    }
  })

export default store
