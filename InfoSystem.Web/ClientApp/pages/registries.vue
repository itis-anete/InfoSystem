<template>
  <v-container class="pl-0 py-0 ml-0 mt-0" fill-height>
    <v-layout>
      <registry-navigation-drawer></registry-navigation-drawer>

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
import { mapGetters, mapActions } from 'vuex'
import RegistryNavigationDrawer from '~/components/RegistryNavigationDrawer.vue'
export default {
  components: {
    RegistryNavigationDrawer
  },
  data() {
    return {}
  },
  computed: {}
}
</script>
