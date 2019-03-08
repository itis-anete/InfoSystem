import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

export const state = () => ({
  attributes: null
})

export const mutations = {
  setAttributes(state, payload) {
    state.attributes = payload
  }
}

export const actions = {
  async getAttributes({ commit }, payload) {
    commit('setLoading', true)
    let response = await axios.get(`/Attribute/GetByTypeId?typeId=${payload}`)
    commit('setAttributes', response.data)
    commit('setLoading', false)
  }
}

export const getters = {
  attributes(state) {
    return state.attributes
  }
}
