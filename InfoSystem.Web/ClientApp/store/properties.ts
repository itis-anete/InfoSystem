import axios from 'axios'
import { VuexModule, Module, MutationAction, Mutation, Action } from 'vuex-module-decorators'
import { Property } from '~/models/property'
import { Entity } from '~/models/entity'

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
  DELETE_PROPERTY(property: Property) {
    let index = this.properties.indexOf(this.properties.find(x => x.id == property.id) as Property)
    this.properties.splice(index, 1)
  }

  @Action({ commit: 'ADD_PROPERTY' })
  async addProperty(property: Property) {
    let response = await axios({ method: 'post', url: `/api/Property/Add`, data: property })
    return response.data as Property
  }

  @Action({ commit: 'UPDATE_PROPERTY' })
  async updateProperty(property: Property) {
    let response = await axios({
      method: 'post',
      url: `/api/Property/Update?typeName=${property.typeName}&newValue=${property.value}&propertyId=${property.id}`
    })
    return response.data as Property
  }

  @Action({ commit: 'DELETE_PROPERTY' })
  async deleteProperty(property: Property) {
    await axios({
      method: 'delete',
      url: `/api/Property/Delete?typeName=${property.typeName}&propertyId=${property.id}`
    })
    return property
  }

  @MutationAction
  async getProperties(entity: Entity) {
    let response = await axios({
      method: 'get',
      url: `/api/Property/GetByTypeName?entityId=${entity.id}&typeName=${entity.typeName}`
    })
    return { properties: response.data as Property[] }
  }
}
