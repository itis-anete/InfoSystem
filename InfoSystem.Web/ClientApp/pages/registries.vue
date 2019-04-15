<template>
  <v-container class="pa-0 ml-0 mt-0" fill-height style="max-width: 100% !important">
    <v-layout>
      <registry-navigation-drawer :types="types.types"></registry-navigation-drawer>
      <v-container class="ma-0 pa-0" style="margin-left: 250px !important;">
        <v-layout justify-center>
          <v-flex xs12>
            <toolbar :newDialog="dialog"></toolbar>
            <v-layout justify-center class="mt-0">
              <v-flex xs11>
                <nuxt-child :key="$route.params.typeName"></nuxt-child>
              </v-flex>
            </v-layout>
          </v-flex>
        </v-layout>
      </v-container>
    </v-layout>
  </v-container>
</template>

<script>
import { mapState } from 'vuex'
import Toolbar from '~/components/toolbar.vue'
import RegistryNavigationDrawer from '~/components/registry/navigation-drawer.vue'
export default {
  components: {
    RegistryNavigationDrawer,
    Toolbar
  },
  computed: {
    ...mapState(['types']),
    dialog() {
      return this.$route.params.id ? 'property-new-dialog' : 'new-entity-dialog'
    }
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
  }
}
</script>