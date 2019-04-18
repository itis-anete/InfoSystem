import axios from 'axios'
import { MenuItem } from '../models/menuItem'

import { Module, VuexModule, MutationAction, Mutation, Action } from 'vuex-module-decorators'

@Module({
  name: 'menu',
  stateFactory: true,
  namespaced: true
})
export default class MenuModule extends VuexModule {
  menuItems: MenuItem[] = []

  drawer: Boolean = false

  get SortedMenuItems() {
    return this.menuItems
  }

  get Drawer() {
    return this.drawer
  }

  @MutationAction
  async getMenuItems() {
    let response = await axios({ method: 'get', url: '/api/Entity/GetMenu' })
    return {
      menuItems: response.data as MenuItem[]
    }
  }

  @Action({ commit: 'ADD_MENU_ITEM' })
  async addMenuItem(payload: MenuItem) {
    const typeName = 'menuitem'
    let entity = await axios({
      method: 'post',
      url: `/api/Entity/Add?typeName=menuitem&requiredAttributeValue=${payload.Title}`
    })
    let property = {
      key: 'link',
      value: payload.Link,
      typeId: entity.data.typeId,
      entityId: entity.data.id
    }
    await axios({
      method: 'post',
      url: `/api/Property/Add`,
      data: property
    })
    property.key = 'icon'
    property.value = payload.Icon
    await axios({
      method: 'post',
      url: `/api/Property/Add`,
      data: property
    })

    let menuItem = await axios({
      method: 'get',
      url: `/api/Property/GetByTypeName?entityId=${entity.data.id}&typeName=${typeName}`
    })

    return menuItem.data as MenuItem
  }

  @Action({ commit: 'SET_DRAWER' })
  async setDrawer(payload: Boolean) {
    return payload
  }

  @Mutation
  ADD_MENU_ITEM(payload: MenuItem) {
    this.menuItems.push(payload)
  }

  @Mutation
  SET_DRAWER(payload: Boolean) {
    this.drawer = payload
  }
}
