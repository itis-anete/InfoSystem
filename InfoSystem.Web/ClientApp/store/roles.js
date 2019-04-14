import axios from 'axios'

export default {
  actions: {
    async createRole({ commit, rootState }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Role/Create?name=${payload.name}&canRead=${payload.canRead}&canWrite=${payload.canWrite}`, {
        headers: { Authorization: rootState.user.token }
      })
      commit('setLoading', false)
    }
  }
}
