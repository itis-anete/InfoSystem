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
      for (let i = 0; i < response.data.length; i++) {
        let propertyName = await axios.get(`/api/Property/GetAttributeValue?typeName=${payload}&attributeName=display`)
        let propertyValue = await axios.get(
          `/api/Property/GetByPropertyName?propertyName=${propertyName.data}&typeName=${payload}&entityId=${response.data[i].id}`
        )
        Vue.set(response.data[i], propertyName.data, propertyValue.data.value)
      }
      setTimeout(() => {
        commit('setEntities', response.data)
      }, 0)
    },
    async addEntity({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Entity/Add?typeName=${payload.typeName}&requiredAttributeValue=${payload.requiredAttributeValue}`)
      let propertyName = await axios.get(`/api/Property/GetAttributeValue?typeName=${payload.typeName}&attributeName=display`)
      let propertyValue = await axios.get(
        `/api/Property/GetByPropertyName?propertyName=${propertyName.data}&typeName=${payload.typeName}&entityId=${response.data.id}`
      )
      Vue.set(response.data, propertyName.data, propertyValue.data.value)
      commit('addEntity', response.data)
      commit('setLoading', false)
    },
    async deleteEntity({ commit }, payload) {
      commit('setLoading', true)
      await axios.delete(`/api/Entity/Delete?id=${payload}`)
      commit('deleteEntity', payload)
      setTimeout(() => {
        commit('setLoading', false)
      }, 500)
    }
  },
  getters: {
    entities(state) {
      return state.entities
    }
  }
}
