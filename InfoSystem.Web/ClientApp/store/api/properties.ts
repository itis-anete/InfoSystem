import { api } from './api'

import { Entity } from '~/models/entity'
import { Property } from '~/models/property'
import { newProperty } from '~/models/newProperty'

export async function getProperties(entity: Entity): Promise<Property[]> {
  const response = await api.get(`/property/GetByTypeName?entityId=${entity.id}&typeName=${entity.typeName}`)
  return response.data as Property[]
}

export async function addProperty(newProperty: newProperty): Promise<Property> {
  const response = await api.post(`/property/Add`, newProperty)
  return response.data as Property
}

export async function updateProperty(property: Property): Promise<Property> {
  const response = await api.post(`/property/Update?typeId=${property.typeId}&newValue=${property.value}&propertyId=${property.id}`)
  return response.data as Property
}

export async function deleteProperty(property: Property): Promise<number> {
  await api.delete(`/property/Delete?typeId=${property.typeId}&propertyId=${property.id}`)
  return property.id as number
}
