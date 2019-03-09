import axios from 'axios'

export default {
  state: {
    currentValues: null
  },
  mutations: {
    setCurrentValues(state, payload) {
      state.currentValues = payload
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
      let response = await axios.get(`/Value/GetByTypeId?entityId=${payload.entityId}&typeId=${payload.typeId}`)
      commit('setCurrentValues', response.data)
      commit('setLoading', false)
    },
    async editValue({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.put('/Value/EditValue', payload)
      commit('editCurrentValues', response.data)
      commit('setLoading', false)
    }
  },
  getters: {
    currentValues(state) {
      return state.currentValues
    }
  }
}
