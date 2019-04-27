import { Type } from '../models/type'
import * as api from '@/store/api/types'
import { Module, VuexModule, MutationAction, Action, Mutation } from 'vuex-module-decorators'

@Module({
  name: 'types',
  stateFactory: true,
  namespaced: true
})
export default class TypesModule extends VuexModule {
  types: Type[] = []

  get Types() {
    return this.types
  }

  @MutationAction
  async getTypes() {
    const types = await api.getTypes()
    return { types: types }
  }

  @Action({ commit: 'ADD_TYPE' })
  async addType(type: Type) {
    const addedType = await api.addType(type)
    return addedType
  }

  @Mutation
  ADD_TYPE(type: Type) {
    this.types.push(type)
  }
}
