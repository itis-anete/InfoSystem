import axios from 'axios'
export default {
  state: {
    loading: false,
    headers: []
  },
  mutations: {
    setLoading(state, payload) {
      if (payload) {
        state.loading = true
      } else {
        setTimeout(() => {
          state.loading = false
        }, 500)
      }
    },
    setHeaders(state, payload) {
      state.headers = [{ text: payload, sortable: false }, { text: '', sortable: false }]
    }
  },
  actions: {
    async loadHeaders({ commit }, payload) {
      let response = await axios.get(`/api/Property/GetAttributeValue?typeName=${payload.typeName}&attributeName=display`)
      commit('setHeaders', response.data)
    }
  },
  getters: {
    loading(state) {
      return state.loading
    },
    headers(state) {
      return state.headers
    }
  }
}
