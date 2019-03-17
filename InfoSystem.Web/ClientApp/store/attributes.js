import axios from 'axios'

export default {
  state: {
    attributes: []
  },
  mutations: {
    setAttributes(state, payload) {
      state.attributes = payload
    }
  },
  actions: {
    async getAttributes({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/api/Attribute/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`)
      commit('setAttributes', response.data)
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
