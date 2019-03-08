import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export const state = () => ({
  loading: false
})

export const mutations = {
  setLoading(state, payload) {
    state.loading = payload
  }
}

export const getters = {
  loading(state) {
    return state.loading
  }
}
// const store = () =>
//   new Vuex.Store({
//     state: {
//       entities: null,
//       currentValues: null,
//       attributes: null,
//       loading: false
//     },
//     mutations: {
//       setEntities(state, payload) {
//         state.entities = payload
//       },
//       setCurrentValues(state, payload) {
//         state.currentValues = payload
//       },
//       editCurrentValues(state, payload) {
//         var current = state.currentValues
//         var index = current.findIndex(x => x.id == payload.id)
//         current.splice(index, 1, payload)
//       },
//       setAttributes(state, payload) {
//         state.attributes = payload
//       },
//       setLoading(state, payload) {
//         state.loading = payload
//       }
//     },
//     actions: {
//       async getEntities({ commit }, payload) {
//         commit('setLoading', true)
//         let response = await axios.get(`/Entity/GetByType?typeId=${payload}`)
//         commit('setEntities', response.data)
//         commit('setLoading', false)
//       },
//       async getValues({ commit }, payload) {
//         commit('setLoading', true)
//         let response = await axios.get(`/Value/GetByTypeId?entityId=${payload.entityId}&typeId=${payload.typeId}`)
//         commit('setCurrentValues', response.data)
//         commit('setLoading', false)
//       },
//       async getAttributes({ commit }, payload) {
//         commit('setLoading', true)
//         let response = await axios.get(`/Attribute/GetByTypeId?typeId=${payload}`)
//         commit('setAttributes', response.data)
//         commit('setLoading', false)
//       },
//       async editValue({ commit }, payload) {
//         commit('setLoading', true)
//         let response = await axios.put('/Value/EditValue', payload)
//         commit('editCurrentValues', response.data)
//         commit('setLoading', false)
//       }
//     },
//     getters: {
//       entities(state) {
//         return state.entities
//       },
//       currentValues(state) {
//         return state.currentValues
//       },
//       attributes(state) {
//         return state.attributes
//       },
//       loading(state) {
//         return state.loading
//       }
//     }
//   })

//export default store
