import axios from 'axios'

export default {
  state: {},
  mutations: {},
  actions: {
    async getAttributes({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/api/Attribute/GetByEntityId?entityId=${payload.id}&typeId=${payload.typeId}`)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
      return response.data
    },
    async getAttributesOfComplex({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/api/Attribute/GetByTypeName?entityId=${payload.value}&typeName=${payload.key.substring(8)}`)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
      return response.data
    }
  },
  getters: {}
}
