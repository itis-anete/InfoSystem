import axios from 'axios'
import { User } from '../models/user'
import { VuexModule, Module, MutationAction, Action } from 'vuex-module-decorators'

@Module({
  name: 'users',
  stateFactory: true,
  namespaced: true
})
export default class UsersModule extends VuexModule {
  token: string = ''
  login: string = ''

  @MutationAction
  async authenticate(user: User) {
    let response = await axios({ method: 'get', url: `/api/User/LogIn?login=${user.Login}&password=${user.Password}` })
    window.localStorage['token'] = response.data.token
    window.localStorage['login'] = response.data.login
    return {
      token: response.data.token,
      login: response.data.login
    }
  }
  @MutationAction
  async authenticateFromLocalStorage() {
    return {
      token: window.localStorage['token'],
      login: window.localStorage['login']
    }
  }
  @MutationAction
  async logOut() {
    delete window.localStorage['login']
    delete window.localStorage['token']
    return {
      token: '',
      login: ''
    }
  }
  @Action
  async register(user: User) {
    await axios({ method: 'post', url: `/api/User/Register?login=${user.Login}&password=${user.Password}` })
    this.authenticate(user)
  }
}
