import axios from 'axios'

export default {
  state: {
    attributes: []
  },
  mutations: {
    setAttributes(state, payload) {
      state.attributes = payload
    },
    deleteAttribute(state, payload) {
      state.attributes.splice(state.attributes.indexOf(payload))
    },
    updateAttribute(state, payload) {}
  },
  actions: {
    async getAttributes({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/api/Attribute/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`)
      commit('setAttributes', response.data)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    },
    async updateAttribute({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/api/Attribute/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`)
      commit('updateAttribute', response.data)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    },
    async deleteAttribute({ commit }, payload) {
      commit('setLoading', true)
      //let response = await axios.delete(`/api/Attribute/Delete?id=${payload.id}&typeName=${payload.typeName}`)
      //commit('deleteAttribute', response.data)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    }
  },
  getters: {
    attributes: state => {
      return state.attributes
    }
  }
}
