import axios from 'axios'

export default {
  state: {
    entities: null
  },
  mutations: {
    setEntities(state, payload) {
      state.entities = payload
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
    }
  },
  getters: {
    entities(state) {
      return state.entities
    }
  }
}
