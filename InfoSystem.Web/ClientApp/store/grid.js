import axios from 'axios'
export default {
  state: {
    headers: [],
    rowsPerPageItems: [10, 20, 100, { text: 'All', value: -1 }],
    pagination: {
      rowsPerPage: 10
    }
  },
  mutations: {
    setHeaders(state, payload) {
      state.headers = [{ text: payload, sortable: false }, { text: '', sortable: false }]
    },
    setPagination(state, payload) {
      state.pagination = payload
    }
  },
  actions: {
    async loadHeaders({ commit, rootState }, payload) {
      let response = await axios({
        method: 'get',
        url: `/api/Property/GetAttributeValue?typeName=${payload.typeName}&attributeName=display`,
        headers: { Authorization: rootState.user.token }
      })
      commit('setHeaders', response.data)
    }
  }
}
