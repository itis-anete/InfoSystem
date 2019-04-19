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
  ADD_PROPERTY(payload: Property) {
    this.properties.push(payload)
  }

  @Mutation
  UPDATE_PROPERTY(payload: Property) {
    let property = this.properties.find(x => x.Id == payload.Id) as Property
    property.Value = payload.Value
  }

  @Mutation
  DELETE_PROPERTY(payload: Property) {
    let index = this.properties.indexOf(this.properties.find(x => x.Id == payload.Id) as Property)
    this.properties.splice(index, 1)
  }

  @Action({ commit: 'ADD_PROPERTY' })
  async addProperty(payload: Property) {
    let response = await axios({ method: 'post', url: `/api/Property/Add`, data: payload })
    return response.data as Property
  }

  @Action({ commit: 'UPDATE_PROPERTY' })
  async updateProperty(payload: Property) {
    let response = await axios({
      method: 'post',
      url: `/api/Property/Update?typeName=${payload.TypeName}&newValue=${payload.Value}&propertyId=${payload.Id}`
    })
    return response.data as Property
  }

  @Action({ commit: 'DELETE_PROPERTY' })
  async deleteProperty(payload: Property) {
    await axios({
      method: 'delete',
      url: `/api/Property/Delete?typeName=${payload.TypeName}&propertyId=${payload.Id}`
    })
    return payload
  }

  @MutationAction
  async getProperties(payload: Entity) {
    let response = await axios({
      method: 'get',
      url: `/api/Property/GetByTypeName?entityId=${payload.Id}&typeName=${payload.TypeName}`
    })
    return { properties: response.data as Property[] }
  }
}
