import { api } from './api'

import { MenuItem } from '@/models/menuItem'

export async function getMenuItems(): Promise<MenuItem[]> {
  const response = await api.get('/entity/getMenu')
  return response.data as MenuItem[]
}

export async function addMenuItem(menuItem: MenuItem): Promise<MenuItem> {
  const typeName = 'menuitem'
  const entity = await api.post(`/entityadd?typeId=65&requiredAttributeValue=${menuItem.title}`)
  let property = {
    key: 'link',
    value: menuItem.link,
    typeId: entity.data.typeId,
    entityId: entity.data.id
  }
  await api.post('/property/add', property)
  property.key = 'icon'
  property.value = menuItem.icon
  await api.post('/property/add', property)

  const response = await api.get(`/property/getByTypeName?entityId=${entity.data.id}&typeName=${typeName}`)
  return response.data as MenuItem
}
