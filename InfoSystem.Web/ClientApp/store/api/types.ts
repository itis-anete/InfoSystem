import axios from 'axios'
import { Type } from '@/models/type'

export const api = axios.create({
  baseURL: '/api/type'
})

export async function getTypes(): Promise<Type[]> {
  const response = await api.get('/get')
  return response.data as Type[]
}

export async function addType(type: Type): Promise<Type> {
  const response = await api.post(`/api/Type/Add?typeName=${type.name}&requiredProperty=${type.requiredProperty}`)
  return response.data as Type
}
