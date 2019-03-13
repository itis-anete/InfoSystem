import axios from 'axios'

export default {
  state: {
    attributes: []
  },
  mutations: {
    setAttributes(state, payload) {
      state.attributes = payload
    },
    addAttribute(state, payload) {
      state.attributes.push(payload)
    }
  },
  actions: {
    async getAttributesByTypeName({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/api/Attribute/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`)
      commit('setAttributes', response.data)
      commit('setLoading', false)
    },
    async getAttributes({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.get(`/api/Attribute/GetByEntityId?entityId=${payload.entityId}&typeId=${payload.typeId}`)
      commit('setAttributes', response.data)
      commit('setLoading', false)
    },
    async addAttribute({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(
        `/Attribute/Add?attributeName=${payload.attributeName}&valueType=${payload.valueType}&typeName=${payload.typeName}`
      )
      commit('addAttribute', response.data)
      commit('setLoading', false)
    }
  },
  getters: {
    attributes(state) {
      return state.attributes
    },
    current(state) {
      return state.current
    }
  }
}
