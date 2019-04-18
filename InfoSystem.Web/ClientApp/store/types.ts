import axios from 'axios'
import { Type } from '../models/type'

export interface TypeState {
  types: Type[]
}

export const state = (): TypeState => ({
  types: []
})

export const getters = {
  types(state: TypeState): Type[] {
    return state.types
  }
}

export const mutations = {
  setTypes(state: TypeState, payload: Type[]) {
    state.types = payload
  },
  addType(state: TypeState, payload: Type) {
    state.types.push(payload)
  }
}

export const actions = {
  async getTypes({ commit, rootState }) {
    let response = await axios({ method: 'get', url: '/api/Type/Get', headers: { Authorization: rootState.users.token } })
    commit('setTypes', response.data)
  },
  async addType({ commit, rootState }, payload: Type) {
    let response = await axios({
      method: 'post',
      url: `/api/Type/Add?typeName=${payload.Name}&requiredProperty=${payload.RequiredProperty}`,
      headers: { Authorization: rootState.users.token }
    })
    commit('addType', response.data)
  }
}
