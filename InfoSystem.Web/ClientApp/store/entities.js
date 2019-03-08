import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

export const state = () => ({
  entities: null,
  loading: false
})

export const mutations = {
  setLoading(state, payload) {
    state.loading = payload
  },
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
