import axios from 'axios'
import { User } from '../models/user'

export interface UserState {
  token: String
  login: String
}

export const state = (): UserState => ({
  token: '',
  login: ''
})

export const mutations = {
  setToken(state: UserState, payload: string) {
    state.token = payload
    window.localStorage['token'] = payload
  },
  setLogin(state: UserState, payload: string) {
    state.login = payload
    window.localStorage['login'] = payload
  }
}

export const actions = {
  async authenticateFromLocalStorage({ commit }) {
    commit('setLogin', window.localStorage['login'])
    commit('setToken', window.localStorage['token'])
  },
  async authenticate({ commit }, payload: User) {
    commit('setLoading', true)
    let response = await axios({ method: 'get', url: `/api/User/LogIn?login=${payload.Login}&password=${payload.Password}` })
    commit('setLogin', response.data.login)
    commit('setToken', response.data.token)
    commit('setLoading', false)
  },
  async register({ dispatch, commit }, payload: User) {
    commit('setLoading', true)
    await axios({ method: 'post', url: `/api/User/Register?login=${payload.Login}&password=${payload.Password}` })
    dispatch('authenticate', payload)
    commit('setLoading', false)
  },
  async logOut({ commit }) {
    commit('setLogin', '')
    commit('setToken', '')
    delete window.localStorage['login']
    delete window.localStorage['token']
  }
}
