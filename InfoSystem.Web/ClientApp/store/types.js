import axios from 'axios'

export default {
  state: {
    types: null
  },
  mutations: {
    setTypes(state, payload) {
      state.types = payload
    }
  },
  actions: {
    async getTypes({ commit }) {
      commit('setLoading', true)
      let response = await axios.get('/Type/Get')
      commit('setTypes', response.data)
      commit('setLoading', false)
    }
  },
  getters: {
    types(state) {
      return state.types
    }
  }
}
