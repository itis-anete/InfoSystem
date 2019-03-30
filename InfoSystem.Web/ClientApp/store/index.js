import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

import common from './common'
import properties from './properties'
import entities from './entities'
import types from './types'

const createStore = () => {
  return new Vuex.Store({
    modules: {
      common,
      properties,
      entities,
      types
    }
  })
}

export default createStore
