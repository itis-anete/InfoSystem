import axios from 'axios'
export default {
  state: {
    drawer: true,
    menuItems: []
  },
  mutations: {
    setMenuItems(state, payload) {
      state.menuItems = payload
    },
    addMenuItem(state, payload) {
      state.menuItems.push(payload)
    },
    setDrawer(state, payload) {
      state.drawer = payload
    }
  },
  actions: {
    setDrawer({ commit }, payload) {
      commit('setDrawer', payload)
    },
    async getMenuItems({ commit, rootState }) {
      const typeName = 'menuitem'
      const token = rootState.user.token
      let response = await axios.get(`/api/Entity/GetByTypeName?typeName=${typeName}`, { headers: { Authorization: token } })
      let items = []
      for (let menuItem of response.data) {
        let menuItemProperties = await axios.get(`/api/Property/GetByTypeName?entityId=${menuItem.id}&typeName=${typeName}`, {
          headers: { Authorization: token }
        })
        items.push(menuItemProperties.data)
      }
      commit('setMenuItems', items)
    },
    async addMenuItem({ commit, rootState }, payload) {
      const typeName = 'menuitem'
      let entity = await axios.post(`/api/Entity/Add?typeName=menuitem&requiredAttributeValue=${payload.title}`, {
        headers: { Authorization: rootState.user.token }
      })
      let property = {
        key: 'link',
        value: payload.link,
        typeId: entity.data.typeId,
        entityId: entity.data.id
      }
      await axios.post(`/api/Property/Add`, property, { headers: { Authorization: rootState.user.token } })

      property.key = 'icon'
      property.value = payload.icon
      await axios.post(`/api/Property/Add`, property, { headers: { Authorization: rootState.user.token } })

      let menuItem = await axios.get(`/api/Property/GetByTypeName?entityId=${entity.data.id}&typeName=${typeName}`, {
        headers: { Authorization: rootState.user.token }
      })
      commit('addMenuItem', menuItem.data)
    }
  },
  getters: {
    drawer(state) {
      return state.drawer
    },
    sortedMenuItems(state) {
      return state.menuItems.sort((a, b) => {
        var titleA = a.find(x => x.key == 'title').value
        var titleB = b.find(x => x.key == 'title').value
        if (titleA == 'Home' && titleB == 'Registries') return -1
        else if (titleA == 'Registries' && titleB == 'Home') return 1
        else if (titleA == 'Home') return -1
        else if (titleA == 'Registries') return -1
        else return 1
      })
    }
  }
}
