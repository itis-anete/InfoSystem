import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

import common from './common'
import properties from './properties'
import entities from './entities'
import types from './types'
import roles from './roles'
import menu from './menu'

const createStore = () => {
  return new Vuex.Store({
    modules: {
      common,
      properties,
      entities,
      types,
      roles,
      menu
    }
  })
}

export default createStore
