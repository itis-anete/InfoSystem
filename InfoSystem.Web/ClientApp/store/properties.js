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
    async getProperties({ commit, rootState }, payload) {
      let response = await axios.get(`/api/Property/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`, {
        headers: { Authorization: rootState.user.token }
      })
      setTimeout(() => {
        commit('setProperties', response.data)
      }, 0)
    },
    async updateProperty({ commit, rootState }, payload) {
      commit('setLoading', true)
      let response = await axios.post(
        `/api/Property/Update?typeName=${payload.typeName}&newValue=${payload.newValue}&propertyId=${payload.propertyId}`,
        { headers: { Authorization: rootState.user.token } }
      )
      commit('updateProperty', response.data)
      commit('setLoading', false)
    },
    async addProperty({ commit, rootState }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Property/Add`, payload, { headers: { Authorization: rootState.user.token } })
      commit('addProperty', response.data)
      commit('setLoading', false)
    },
    async deleteProperty({ commit, rootState }, payload) {
      commit('setLoading', true)
      await axios.delete(`/api/Property/Delete?typeName=${payload.typeName}&propertyId=${payload.propertyId}`, {
        headers: { Authorization: rootState.user.token }
      })
      commit('deleteProperty', payload)
      commit('setLoading', false)
    }
  }
}
