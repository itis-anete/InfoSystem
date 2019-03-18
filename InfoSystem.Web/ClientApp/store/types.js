import axios from 'axios'

export default {
  state: {
    types: []
  },
  mutations: {
    setTypes(state, payload) {
      state.types = payload
    },
    addType(state, payload) {
      state.types.push(payload)
    }
  },
  actions: {
    async getTypes({ commit }) {
      let response = await axios.get('/api/Type/Get')
      commit('setTypes', response.data)
    },
    async addType({ commit }, payload) {
      let response = await axios.post(`/api/Type/Add?typeName=${payload}`)
      commit('addType', response.data)
    }
  },
  getters: {
    types(state) {
      return state.types
    }
  }
}
