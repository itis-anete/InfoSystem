import axios from 'axios'

export default {
  state: {
    entities: []
  },
  mutations: {
    setEntities(state, payload) {
      state.entities = payload
    },
    addEntity(state, payload) {
      state.entities.push(payload)
    }
  },
  actions: {
    async getEntities({ commit }, payload) {
      let response = await axios.get(`/api/Entity/GetByTypeName?typeName=${payload}`)
      setTimeout(() => {
        commit('setEntities', response.data)
      }, 0)
    },
    async addEntity({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Entity/Add?typeName=${payload}`)
      commit('addEntity', response.data)
      commit('setLoading', false)
    }
  },
  getters: {
    entities(state) {
      return state.entities
    }
  }
}
