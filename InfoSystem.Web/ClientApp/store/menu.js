import axios from 'axios'
export default {
  state: {
    drawer: false,
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
    async getMenuItems({ commit }) {
      const typeName = 'menuitem'
      let response = await axios.get(`/api/Entity/GetByTypeName?typeName=${typeName}`)
      let items = []
      for (let menuItem of response.data) {
        let menuItemProperties = await axios.get(`/api/Property/GetByTypeName?entityId=${menuItem.id}&typeName=${typeName}`)
        items.push(menuItemProperties.data)
      }
      commit('setMenuItems', items)
    },
    async addMenuItem({ commit }, payload) {
      const typeName = 'menuitem'
      let entity = await axios.post(`/api/Entity/Add?typeName=menuitem&requiredAttributeValue=${payload.title}`)
      let property = {
        key: 'link',
        value: payload.link,
        typeId: entity.data.typeId,
        entityId: entity.data.id
      }
      await axios.post(`/api/Property/Add`, property)

      property.key = 'icon'
      property.value = payload.icon
      await axios.post(`/api/Property/Add`, property)

      let menuItem = await axios.get(`/api/Property/GetByTypeName?entityId=${entity.data.id}&typeName=${typeName}`)
      commit('addMenuItem', menuItem.data)
    }
  },
  getters: {
    drawer(state) {
      return state.drawer
    },
    menuItems(state) {
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
