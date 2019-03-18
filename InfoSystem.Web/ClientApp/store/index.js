import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

import common from './common'
import attributes from './attributes'
import entities from './entities'
import types from './types'

const createStore = () => {
  return new Vuex.Store({
    modules: {
      common,
      attributes,
      entities,
      types
    }
  })
}

export default createStore
