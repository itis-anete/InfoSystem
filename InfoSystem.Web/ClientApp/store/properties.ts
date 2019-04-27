import * as api from '@/store/api/properties'
import { VuexModule, Module, MutationAction, Mutation, Action } from 'vuex-module-decorators'
import { Property } from '~/models/property'
import { Entity } from '~/models/entity'
import properties from '@/store/properties'
import { newProperty } from '~/models/newProperty'

@Module({
  name: 'properties',
  stateFactory: true,
  namespaced: true
})
export default class PropertiesModule extends VuexModule {
  properties: Property[] = []

  get Properties() {
    return this.properties
  }

  @MutationAction
  async getProperties(entity: Entity) {
    const properties = await api.getProperties(entity)
    return { properties: properties }
  }

  @Action({ commit: 'ADD_PROPERTY' })
  async addProperty(newProperty: newProperty) {
    const addedProperty = await api.addProperty(newProperty)
    return addedProperty
  }

  @Action({ commit: 'UPDATE_PROPERTY' })
  async updateProperty(property: Property) {
    const updatedProperty = await api.updateProperty(property)
    return updatedProperty
  }

  @Action({ commit: 'DELETE_PROPERTY' })
  async deleteProperty(property: Property) {
    const deletedPropertyId = await api.deleteProperty(property)
    return deletedPropertyId
  }

  @Mutation
  ADD_PROPERTY(property: Property) {
    this.properties.push(property)
  }

  @Mutation
  UPDATE_PROPERTY(updatedProperty: Property) {
    let property = this.properties.find(x => x.id == updatedProperty.id) as Property
    property.value = updatedProperty.value
  }

  @Mutation
  DELETE_PROPERTY(id: number) {
    let index = this.properties.indexOf(this.properties.find(x => x.id == id) as Property)
    this.properties.splice(index, 1)
  }
}
