import { Entity } from '../models/entity'
import * as api from '@/store/api/entities'
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
    const entities = await api.getEntities(typeName)
    return { entities: entities }
  }

  @MutationAction
  async getCurrentEntityDisplay(entity: Entity) {
    const displayValue = await api.getCurrentEntityDisplay(entity)
    return { currentEntityDisplay: displayValue }
  }

  @Action({ commit: 'ADD_ENTITY' })
  async addEntity(entity: Entity) {
    const addedEntity = await api.addEntity(entity)
    return addedEntity
  }

  @Action({ commit: 'DELETE_ENTITY' })
  async deleteEntity(entity: Entity) {
    const deletedEntityId = api.deleteEntity(entity)
    return deletedEntityId
  }

  @Mutation
  ADD_ENTITY(entity: Entity) {
    this.entities.push(entity)
  }

  @Mutation
  DELETE_ENTITY(id: number) {
    let index = this.entities.indexOf(this.entities.find(x => x.id == id) as Entity)
    this.entities.splice(index, 1)
  }
}
