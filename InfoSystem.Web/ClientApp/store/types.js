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
      commit('setLoading', true)
      let response = await axios.get('/Type/Get')
      commit('setTypes', response.data)
      commit('setLoading', false)
    },
    async addType({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/Type/Add?typeName=${payload.typeName}&identificator=${payload.identificator}`)
      commit('addType', response.data)
      commit('setLoading', false)
    }
  },
  getters: {
    types(state) {
      return state.types
    }
  }
}
