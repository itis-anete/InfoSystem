import axios from 'axios'

export default {
  state: {
    currentValues: []
  },
  mutations: {
    setCurrentValues(state, payload) {
      state.currentValues = payload
    },
    addValue(state, payload) {
      state.currentValues.push(payload)
    },
    editCurrentValues(state, payload) {
      var current = state.currentValues
      var index = current.findIndex(x => x.id == payload.id)
      current.splice(index, 1, payload)
    }
  },
  actions: {
    async getValues({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/Value/GetEntityValues?entityId=${payload}`)
      commit('setCurrentValues', response.data)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    },
    async editValue({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.put('/Value/EditValue', payload)
      commit('editCurrentValues', response.data)
      commit('setLoading', false)
    },
    async addValue({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post('/Value/Add', payload)
      commit('addValue', response.data)
      commit('setLoading', false)
    }
  },
  getters: {
    currentValues(state) {
      return state.currentValues
    }
  }
}
