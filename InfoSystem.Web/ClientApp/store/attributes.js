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
      let response = await axios.get(`/api/Attribute/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`)
      setTimeout(() => {
        commit('setAttributes', response.data)
      }, 0)
    }
  },
  getters: {
    attributes: state => {
      return state.attributes
    }
  }
}
