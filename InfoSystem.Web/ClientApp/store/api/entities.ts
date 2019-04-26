import axios from 'axios'
import { Entity } from '@/models/entity'
import { Property } from '../../models/property'

export const api = axios.create({
  baseURL: '/api/entity'
})

export async function getEntities(typeName: string): Promise<Entity[]> {
  const response = await api.get(`/GetByTypeName?typeName=${typeName}`)
  return response.data as Entity[]
}

export async function addEntity(entity: Entity): Promise<Entity> {
  const response = await api.get(`/Add?typeName=${entity.TypeName}&requiredAttributeValue=${entity.RequiredAttributeValue}`)
  return response.data as Entity
}

export async function getCurrentEntityDisplay(entity: Entity): Promise<Property> {
  const displayKey = await api.get(`/GetAttributeValue?typeName=${entity.TypeName}`)
  const response = await api.get(`/GetByPropertyName?typeName=${entity.TypeName}&entityId=${entity.Id}&propertyName=${displayKey.data}`)
  return response.data as Property
}

export async function deleteEntity(entity: Entity): Promise<number> {
  const response = await api.delete(`/Delete?id=${entity.Id}`)
  return response.data as number
}
