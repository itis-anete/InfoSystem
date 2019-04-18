import axios from 'axios'
import { Type } from '../models/type'
import { Module, VuexModule, MutationAction, Action, Mutation } from 'vuex-module-decorators'

@Module({
  name: 'types',
  stateFactory: true,
  namespaced: true
})
export default class TypesModule extends VuexModule {
  types: Type[] = []

  @MutationAction
  async getTypes() {
    let response = await axios({
      method: 'get',
      url: '/api/Type/Get'
    })
    return {
      types: response.data as Type[]
    }
  }

  @Action({ commit: 'ADD_TYPE' })
  async addType(payload: Type) {
    let response = await axios({
      method: 'post',
      url: `/api/Type/Add?typeName=${payload.Name}&requiredProperty=${payload.RequiredProperty}`
    })
    return response.data as Type
  }

  @Mutation
  ADD_TYPE(payload: Type) {
    this.types.push(payload)
  }
}
