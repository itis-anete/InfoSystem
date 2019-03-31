import axios from 'axios'

export default {
  actions: {
    async createRole({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Role/Create?name=${payload.name}&canRead=${payload.canRead}&canWrite=${payload.canWrite}`)
      commit('setLoading', false)
    }
  }
}
