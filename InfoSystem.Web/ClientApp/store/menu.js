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
      const token = rootState.user.token
      let response = await axios({ method: 'get', url: '/api/Entity/GetMenu', headers: { Authorization: token } })
      commit('setMenuItems', response.data)
    },
    async addMenuItem({ commit, rootState }, payload) {
      const typeName = 'menuitem'
      let entity = await axios({
        method: 'post',
        url: `/api/Entity/Add?typeName=menuitem&requiredAttributeValue=${payload.title}`,
        headers: { Authorization: rootState.user.token }
      })
      let property = {
        key: 'link',
        value: payload.link,
        typeId: entity.data.typeId,
        entityId: entity.data.id
      }
      await axios({ method: 'post', url: `/api/Property/Add`, data: property, headers: { Authorization: rootState.user.token } })

      property.key = 'icon'
      property.value = payload.icon
      await axios({ method: 'post', url: `/api/Property/Add`, data: property, headers: { Authorization: rootState.user.token } })

      let menuItem = await axios({
        method: 'get',
        url: `/api/Property/GetByTypeName?entityId=${entity.data.id}&typeName=${typeName}`,
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
