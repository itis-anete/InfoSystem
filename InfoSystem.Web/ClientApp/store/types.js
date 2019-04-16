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
    async getTypes({ commit, rootState }) {
      let response = await axios({ method: 'get', url: '/api/Type/Get', headers: { Authorization: rootState.user.token } })
      commit('setTypes', response.data)
    },
    async addType({ commit, rootState }, payload) {
      let response = await axios({
        method: 'post',
        url: `/api/Type/Add?typeName=${payload.typeName}&requiredProperty=${payload.requiredProperty}`,
        headers: { Authorization: rootState.user.token }
      })
      commit('addType', response.data)
    }
  }
}
