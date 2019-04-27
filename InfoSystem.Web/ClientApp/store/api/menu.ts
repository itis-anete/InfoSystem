import axios from 'axios'
import { MenuItem } from '@/models/menuItem'

export const entityApi = axios.create({
  baseURL: '/api/entity'
})

export const propertyApi = axios.create({
  baseURL: '/api/property'
})

export async function getMenuItems(): Promise<MenuItem[]> {
  const response = await entityApi.get('/getMenu')
  return response.data as MenuItem[]
}

export async function addMenuItem(menuItem: MenuItem): Promise<MenuItem> {
  const typeName = 'menuitem'
  const entity = await entityApi.post(`add?typeId=65&requiredAttributeValue=${menuItem.title}`)
  let property = {
    key: 'link',
    value: menuItem.link,
    typeId: entity.data.typeId,
    entityId: entity.data.id
  }
  await propertyApi.post('/add', property)
  property.key = 'icon'
  property.value = menuItem.icon
  await propertyApi.post('/add', property)

  const response = await propertyApi.get(`/getByTypeName?entityId=${entity.data.id}&typeName=${typeName}`)
  return response.data as MenuItem
}
