export default {
  state: {
    loading: false,
    drawer: false
  },
  mutations: {
    setLoading(state, payload) {
      state.loading = payload
    },
    setDrawer(state, payload) {
      state.drawer = payload
    }
  },
  actions: {
    setDrawer({ commit }, payload) {
      commit('setDrawer', payload)
    }
  },
  getters: {
    loading(state) {
      return state.loading
    },
    drawer(state) {
      return state.drawer
    }
  }
}
