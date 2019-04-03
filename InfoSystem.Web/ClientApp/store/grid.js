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
    async loadHeaders({ commit }, payload) {
      let response = await axios.get(`/api/Property/GetAttributeValue?typeName=${payload.typeName}&attributeName=display`)
      commit('setHeaders', response.data)
    }
  },
  getters: {
    headers(state) {
      return state.headers
    },
    rowsPerPageItems(state) {
      return state.rowsPerPageItems
    },
    pagination(state) {
      return state.pagination
    }
  }
}
