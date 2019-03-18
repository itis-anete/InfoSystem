import axios from 'axios'

export default {
  state: {
    attributes: []
  },
  mutations: {
    setAttributes(state, payload) {
      state.attributes = payload
    },
    deleteAttribute(state, payload) {
      let index = state.attributes.indexOf(state.attributes.find(x => x.id == payload.attributeId))
      state.attributes.splice(index, 1)
    },
    addAttribute(state, payload) {
      state.attributes.push(payload)
    },
    updateAttribute(state, payload) {
      let attribute = state.attributes.find(x => x.id == payload.id)
      attribute.value = payload.value
    }
  },
  actions: {
    async getAttributes({ commit }, payload) {
      let response = await axios.get(`/api/Attribute/GetByTypeName?entityId=${payload.entityId}&typeName=${payload.typeName}`)
      setTimeout(() => {
        commit('setAttributes', response.data)
      }, 0)
    },
    async updateAttribute({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(
        `/api/Attribute/Update?typeName=${payload.typeName}&newValue=${payload.newValue}&attributeId=${payload.attributeId}`
      )
      commit('updateAttribute', response.data)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    },
    async addAttribute({ commit }, payload) {
      commit('setLoading', true)
      let response = await axios.post(`/api/Attribute/Add`, payload)
      commit('addAttribute', response.data)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    },
    async deleteAttribute({ commit }, payload) {
      commit('setLoading', true)
      await axios.delete(`/api/Attribute/Delete?typeName=${payload.typeName}&attributeId=${payload.attributeId}`)
      commit('deleteAttribute', payload)
      setTimeout(() => {
        commit('setLoading', false)
      }, 550)
    }
  },
  getters: {
    attributes: state => {
      return state.attributes
    }
  }
}
