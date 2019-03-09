<template>
  <v-container class="pl-0 py-0 ml-0 mt-0" fill-height>
    <v-layout>
      <registry-navigation-drawer :types="types"></registry-navigation-drawer>
      <v-container class="ma-0">
        <v-layout justify-center>
          <v-flex xs12 sm8 md6>
            <nuxt-child></nuxt-child>
          </v-flex>
        </v-layout>
      </v-container>
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
