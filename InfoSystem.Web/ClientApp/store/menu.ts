import axios from 'axios'
import { MenuItem } from '../models/menuItem'

export interface MenuState {
  drawer: Boolean
  menuItems: MenuItem[]
}

export const state = (): MenuState => ({
  drawer: false,
  menuItems: []
})

export const getters = {
  drawer(state: MenuState) {
    return state.drawer
  },
  sortedMenuItems(state: MenuState) {
    return state.menuItems
    // return state.menuItems.sort((a: any, b: any) => {
    //   var titleA = a.find(x => x.key == 'title').value
    //   var titleB = b.find(x => x.key == 'title').value
    //   if (titleA == 'Home' && titleB == 'Registries') return -1
    //   else if (titleA == 'Registries' && titleB == 'Home') return 1
    //   else if (titleA == 'Home') return -1
    //   else if (titleA == 'Registries') return -1
    //   else return 1
    // })
  }
}

export const mutations = {
  setMenuItems(state: MenuState, payload: MenuItem[]) {
    state.menuItems = payload
  },
  addMenuItem(state: MenuState, payload: MenuItem) {
    state.menuItems.push(payload)
  },
  setDrawer(state: MenuState, payload: Boolean) {
    state.drawer = payload
  }
}

export const actions = {
  setDrawer({ commit }, payload: Boolean) {
    commit('setDrawer', payload)
  },
  async getMenuItems({ commit, rootState }) {
    const token = rootState.users.token
    let response = await axios({ method: 'get', url: '/api/Entity/GetMenu', headers: { Authorization: token } })
    commit('setMenuItems', response.data as MenuItem[])
  },
  async addMenuItem({ commit, rootState }, payload: MenuItem) {
    const typeName = 'menuitem'
    let entity = await axios({
      method: 'post',
      url: `/api/Entity/Add?typeName=menuitem&requiredAttributeValue=${payload.Title}`,
      headers: { Authorization: rootState.users.token }
    })
    let property = {
      key: 'link',
      value: payload.Link,
      typeId: entity.data.typeId,
      entityId: entity.data.id
    }
    await axios({ method: 'post', url: `/api/Property/Add`, data: property, headers: { Authorization: rootState.users.token } })

    property.key = 'icon'
    property.value = payload.Icon
    await axios({ method: 'post', url: `/api/Property/Add`, data: property, headers: { Authorization: rootState.users.token } })

    let menuItem = await axios({
      method: 'get',
      url: `/api/Property/GetByTypeName?entityId=${entity.data.id}&typeName=${typeName}`,
      headers: { Authorization: rootState.users.token }
    })
    commit('addMenuItem', menuItem.data)
  }
}
