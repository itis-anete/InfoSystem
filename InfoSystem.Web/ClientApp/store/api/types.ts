import { api } from './api'

import { Type } from '@/models/type'

export async function getTypes(): Promise<Type[]> {
  const response = await api.get('/type/get')
  return response.data as Type[]
}

export async function addType(type: Type): Promise<Type> {
  const response = await api.post(`/type/Add?typeName=${type.name}&requiredProperty=${type.requiredProperty}`)
  return response.data as Type
}
