import axios from 'axios'
export default {
  state: {
    loading: false,
    drawer: false,
    menuItems: []
  },
  mutations: {
    setLoading(state, payload) {
      state.loading = payload
    },
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
      let response = await axios.get(`/api/Entity/GetByTypeName?typeName=menuitem`)
      let items = []
      response.data.forEach(element => {
        axios.get(`/api/Property/GetByTypeName?entityId=${element.id}&typeName=menuitem`).then(x => {
          items.push(x.data)
        })
        commit('setMenuItems', items)
      })
    },
    async addMenuItem({ commit }, payload) {
      let entity = await axios.post(`/api/Entity/Add?typeName=menuitem&requiredAttributeValue=${payload.title}`)

      let property = {
        key: 'link',
        value: payload.link,
        typeId: 65,
        entityId: entity.data.id
      }
      await axios.post(`/api/Property/Add`, property)

      property.key = 'icon'
      property.value = payload.icon
      await axios.post(`/api/Property/Add`, property)

      let menuItem = await axios.get(`/api/Property/GetByTypeName?entityId=${entity.data.id}&typeName=menuitem`)
      commit('addMenuItem', menuItem.data)
    }
  },
  getters: {
    loading(state) {
      return state.loading
    },
    drawer(state) {
      return state.drawer
    },
    menuItems(state) {
      return state.menuItems
    }
  }
}
