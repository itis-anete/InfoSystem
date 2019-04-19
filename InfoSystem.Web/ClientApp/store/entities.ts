import axios from 'axios'
import { Entity } from '../models/entity'
import { Module, VuexModule, MutationAction, Action, Mutation } from 'vuex-module-decorators'

@Module({
  name: 'entities',
  stateFactory: true,
  namespaced: true
})
export default class EntitiesModule extends VuexModule {
  entities: Entity[] = []
  currentEntityDisplay: String = ''

  get Entities() {
    return this.entities
  }

  get CurrentEntityDisplay() {
    return this.currentEntityDisplay
  }

  @MutationAction
  async getEntities(payload: string) {
    let response = await axios({
      method: 'get',
      url: `/api/Entity/GetByTypeName?typeName=${payload}`
    })
    return {
      entities: response.data as Entity[]
    }
  }

  @MutationAction
  async getCurrentEntityDisplay(payload: Entity) {
    let displayKey = await axios({
      method: 'get',
      url: `/api/Property/GetAttributeValue?typeName=${payload.TypeName}`
    })
    let response = await axios({
      method: 'get',
      url: `/api/Property/GetByPropertyName?typeName=${payload.TypeName}&entityId=${payload.Id}&propertyName=${displayKey.data}`
    })
    return {
      currentEntityDisplay: response.data as String
    }
  }

  @Action({ commit: 'ADD_ENTITY' })
  async addEntity(payload: Entity) {
    let response = await axios({
      method: 'post',
      url: `/api/Entity/Add?typeName=${payload.TypeName}&requiredAttributeValue=${payload.RequiredAttributeValue}`
    })
    return response.data as Entity
  }

  @Action({ commit: 'DELETE_ENTITY' })
  async deleteEntity(payload: Entity) {
    await axios({ method: 'delete', url: `/api/Entity/Delete?id=${payload.Id}` })
    return payload
  }

  @Mutation
  ADD_ENTITY(payload: Entity) {
    this.entities.push(payload)
  }

  @Mutation
  DELETE_ENTITY(payload: Entity) {
    let index = this.entities.indexOf(this.entities.find(x => x.Id == payload.Id) as Entity)
    this.entities.splice(index, 1)
  }
}
