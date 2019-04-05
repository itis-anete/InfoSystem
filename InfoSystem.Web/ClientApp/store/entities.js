import axios from 'axios'
import Vue from 'vue'

export default {
  state: {
    entities: []
  },
  mutations: {
    setEntities(state, payload) {
      state.entities = payload
    },
    addEntity(state, payload) {
      state.entities.push(payload)
    },
    deleteEntity(state, payload) {
      let index = state.entities.indexOf(state.entities.find(x => x.id == payload))
      state.entities.splice(index, 1)
    }
  },
  actions: {
    async getEntities({ commit }, payload) {
      let response = await axios.get(`/api/Entity/GetByTypeName?typeName=${payload}`)
      setTimeout(() => {
        commit('setEntities', response.data)
      }, 0)
    },
    async addEntity({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Entity/Add?typeName=${payload.typeName}&requiredAttributeValue=${payload.requiredAttributeValue}`)
      commit('addEntity', response.data)
      commit('setLoading', false)
    },
    async deleteEntity({ commit }, payload) {
      commit('setLoading', true)
      await axios.delete(`/api/Entity/Delete?id=${payload}`)
      commit('deleteEntity', payload)
      commit('setLoading', false)
    }
  }
}
