import axios from 'axios'

export default {
  state: {
    attributes: null
  },
  mutations: {
    setAttributes(state, payload) {
      state.attributes = payload
    }
  },
  actions: {
    async getAttributes({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/Attribute/GetAttributesByTypeId?typeId=${payload}`)
      commit('setAttributes', response.data)
      commit('setLoading', false)
    }
  },
  getters: {
    attributes(state) {
      return state.attributes
    }
  }
}
