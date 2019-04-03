import axios from 'axios'

export default {
  state: {
    properties: []
  },
  mutations: {
    setProperties(state, payload) {
      state.properties = payload
    },
    addProperty(state, payload) {
      state.properties.push(payload)
    },
    updateProperty(state, payload) {
      let property = state.properties.find(x => x.id == payload.id)
      property.value = payload.value
    },
    deleteProperty(state, payload) {
      let index = state.properties.indexOf(state.properties.find(x => x.id == payload.propertyId))
      state.properties.splice(index, 1)
    }
  },
  actions: {
    async getProperties({ commit }, payload) {
      let response = await axios.get(`/api/Property/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`)
      setTimeout(() => {
        commit('setProperties', response.data)
      }, 0)
    },
    async updateProperty({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(
        `/api/Property/Update?typeName=${payload.typeName}&newValue=${payload.newValue}&propertyId=${payload.propertyId}`
      )
      commit('updateProperty', response.data)
      commit('setLoading', false)
    },
    async addProperty({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Property/Add`, payload)
      commit('addProperty', response.data)
      commit('setLoading', false)
    },
    async deleteProperty({ commit }, payload) {
      commit('setLoading', true)
      await axios.delete(`/api/Property/Delete?typeName=${payload.typeName}&attributeId=${payload.attributeId}`)
      commit('deleteProperty', payload)
      commit('setLoading', false)
    }
  },
  getters: {
    properties: state => {
      return state.properties
    }
  }
}
