import axios from 'axios'
import { Entity } from '~/models/entity'
import { Property } from '~/models/property'

export const api = axios.create({
  baseURL: '/api/property'
})

export async function getProperties(entity: Entity): Promise<Property[]> {
  const response = await api.get(`/GetByTypeName?entityId=${entity.id}&typeName=${entity.typeName}`)
  return response.data as Property[]
}

export async function addProperty(property: Property): Promise<Property> {
  const response = await api.post(`/Add`, property)
  return response.data as Property
}

export async function updateProperty(property: Property): Promise<Property> {
  const response = await api.post(`/Update?typeId=${property.typeId}&newValue=${property.value}&propertyId=${property.id}`)
  return response.data as Property
}

export async function deleteProperty(property: Property): Promise<number> {
  await api.delete(`/Delete?typeId=${property.typeId}&propertyId=${property.id}`)
  return property.id as number
}
