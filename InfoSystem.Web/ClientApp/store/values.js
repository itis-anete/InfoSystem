import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

export const state = () => ({
  currentValues: null
})

export const mutations = () => ({
  setCurrentValues(state, payload) {
    state.currentValues = payload
  },
  editCurrentValues(state, payload) {
    var current = state.currentValues
    var index = current.findIndex(x => x.id == payload.id)
    current.splice(index, 1, payload)
  }
})

export const actions = () => ({
  async getValues({ commit }, payload) {
    commit('setLoading', true)
    let response = await axios.get(`/Value/GetByTypeId?entityId=${payload.entityId}&typeId=${payload.typeId}`)
    commit('setCurrentValues', response.data)
    commit('setLoading', false)
  },
  async editValue({ commit }, payload) {
    commit('setLoading', true)
    let response = await axios.put('/Value/EditValue', payload)
    commit('editCurrentValues', response.data)
    commit('setLoading', false)
  }
})

export const getters = () => ({
  currentValues(state) {
    return state.currentValues
  }
})
