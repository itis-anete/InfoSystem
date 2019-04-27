import { api } from './api'

import { Entity } from '@/models/entity'
import { Property } from '../../models/property'

export async function getEntities(typeName: string): Promise<Entity[]> {
  const response = await api.get(`/entity/GetByTypeName?typeName=${typeName}`)
  return response.data as Entity[]
}

export async function addEntity(entity: Entity): Promise<Entity> {
  const response = await api.post(`/entity/Add?typeId=${entity.typeId}&requiredAttributeValue=${entity.requiredAttributeValue}`)
  return response.data as Entity
}

export async function getCurrentEntityDisplay(entity: Entity): Promise<string> {
  const displayKey = await api.get(`/property/GetAttributeValue?typeName=${entity.typeName}&attributeName=display`)
  const response = await api.get(`/property/GetByPropertyName?typeName=${entity.typeName}&entityId=${entity.id}&propertyName=${displayKey.data}`)
  const property = response.data as Property
  return property.value
}

export async function deleteEntity(entity: Entity): Promise<number> {
  await api.delete(`/entity/Delete?id=${entity.id}`)
  return entity.id as number
}
