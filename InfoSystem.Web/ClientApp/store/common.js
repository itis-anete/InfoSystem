export default {
  state: {
    loading: false
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
    }
  },
  actions: {},
  getters: {
    loading(state) {
      return state.loading
    }
  }
}
