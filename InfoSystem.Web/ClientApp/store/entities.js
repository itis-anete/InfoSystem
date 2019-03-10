import axios from 'axios'

export default {
  state: {
    entities: null
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
      commit('setLoading', true)
      let response = await axios.get(`/Entity/GetByType?typeId=${payload}`)
      commit('setEntities', response.data)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    },
    async addEntity({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/Entity/Add?typeName=${payload.typeName}&identificator=${payload.identificator}`)
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
