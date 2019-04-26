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
  currentEntityDisplay: string = ''

  get Entities() {
    return this.entities
  }

  get CurrentEntityDisplay() {
    return this.currentEntityDisplay
  }

  @MutationAction
  async getEntities(typeName: string) {
    let response = await axios({
      method: 'get',
      url: `/api/Entity/GetByTypeName?typeName=${typeName}`
    })
    return {
      entities: response.data as Entity[]
    }
  }

  @MutationAction
  async getCurrentEntityDisplay(entity: Entity) {
    let displayKey = await axios({
      method: 'get',
      url: `/api/Property/GetAttributeValue?typeName=${entity.TypeName}`
    })
    let response = await axios({
      method: 'get',
      url: `/api/Property/GetByPropertyName?typeName=${entity.TypeName}&entityId=${entity.Id}&propertyName=${displayKey.data}`
    })
    return {
      currentEntityDisplay: response.data as string
    }
  }

  @Action({ commit: 'ADD_ENTITY' })
  async addEntity(entity: Entity) {
    let response = await axios({
      method: 'post',
      url: `/api/Entity/Add?typeName=${entity.TypeName}&requiredAttributeValue=${entity.RequiredAttributeValue}`
    })
    return response.data as Entity
  }

  @Action({ commit: 'DELETE_ENTITY' })
  async deleteEntity(entity: Entity) {
    await axios({ method: 'delete', url: `/api/Entity/Delete?id=${entity.Id}` })
    return entity
  }

  @Mutation
  ADD_ENTITY(entity: Entity) {
    this.entities.push(entity)
  }

  @Mutation
  DELETE_ENTITY(entity: Entity) {
    let index = this.entities.indexOf(this.entities.find(x => x.Id == entity.Id) as Entity)
    this.entities.splice(index, 1)
  }
}
