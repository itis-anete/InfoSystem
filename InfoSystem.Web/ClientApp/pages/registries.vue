<template>
  <v-container class="pa-0 ml-0 mt-0" fill-height style="max-width: 100% !important">
    <v-layout>
      <registry-navigation-drawer :types="types.types"></registry-navigation-drawer>
      <nuxt-child :key="$route.params.typeName"></nuxt-child>
    </v-layout>
  </v-container>
</template>

<script>
import { mapState } from 'vuex'
import RegistryNavigationDrawer from '~/components/registry/navigation-drawer.vue'
export default {
  components: {
    RegistryNavigationDrawer
  },
  computed: mapState(['types']),
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
  }
}
</script>
