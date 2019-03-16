<template>
  <v-container class="pl-0 py-0 ml-0 mt-0" fill-height>
    <v-layout>
      <registry-navigation-drawer :types="types"></registry-navigation-drawer>
      <nuxt-child></nuxt-child>
    </v-layout>
  </v-container>
</template>

<script>
import { mapGetters } from 'vuex'
import RegistryNavigationDrawer from '~/components/registry/navigation-drawer.vue'
export default {
  components: {
    RegistryNavigationDrawer
  },
  computed: {
    ...mapGetters(['types'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
  }
}
</script>
