import axios from 'axios'

export const state = () => ({
  entities: null
})

export const mutations = {
  setEntities(state, payload) {
    state.entities = payload
  }
}

export const actions = {
  async getEntities({ commit }, payload) {
    commit('setLoading', true)
    let response = await axios.get(`/Entity/GetByType?typeId=${payload}`)
    commit('setEntities', response.data)
    commit('setLoading', false)
  }
}

export const getters = {
  entities(state) {
    return state.entities
  }
}
