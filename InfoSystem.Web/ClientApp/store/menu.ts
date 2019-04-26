import * as api from '@/store/api/menu'
import { MenuItem } from '../models/menuItem'

import { Module, VuexModule, MutationAction, Mutation, Action } from 'vuex-module-decorators'

@Module({
  name: 'menu',
  stateFactory: true,
  namespaced: true
})
export default class MenuModule extends VuexModule {
  menuItems: MenuItem[] = []

  drawer: boolean = false

  get SortedMenuItems() {
    return this.menuItems
  }

  get Drawer() {
    return this.drawer
  }

  @MutationAction
  async getMenuItems() {
    const menuItems = await api.getMenuItems()
    return {
      menuItems: menuItems
    }
  }

  @Action({ commit: 'ADD_MENU_ITEM' })
  async addMenuItem(menuItem: MenuItem) {
    const addedMenuItem = await api.addMenuItem(menuItem)
    return addedMenuItem
  }

  @Action({ commit: 'SET_DRAWER' })
  async setDrawer(isActive: boolean) {
    return isActive
  }

  @Mutation
  ADD_MENU_ITEM(menuItem: MenuItem) {
    this.menuItems.push(menuItem)
  }

  @Mutation
  SET_DRAWER(isActive: boolean) {
    this.drawer = isActive
  }
}
