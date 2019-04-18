<template>
  <v-container class="pa-0 ml-0 mt-0" fill-height style="max-width: 100% !important">
    <v-layout>
      <registry-navigation-drawer :types="types" />
      <v-container class="ma-0 pa-0" style="margin-left: 250px !important; max-width: 100% !important">
        <v-layout justify-center>
          <v-flex xs12>
            <toolbar v-if="$route.params.typeName" :newDialog="dialog"></toolbar>
            <v-layout justify-center class="mt-0">
              <v-flex xs11>
                <nuxt-child :key="$route.params.typeName" />
              </v-flex>
            </v-layout>
          </v-flex>
        </v-layout>
      </v-container>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'
import { Getter, Action } from 'vuex-class'
import Toolbar from '~/components/toolbar.vue'
import RegistryNavigationDrawer from '~/components/registry/navigation-drawer.vue'
import { Type } from '../models/type'

@Component({
  components: {
    RegistryNavigationDrawer,
    Toolbar
  },
  name: 'Registries'
})
export default class extends Vue {
  @Getter('types/types') types!: Type[]

  get dialog(): string {
    return this.$route.params.id ? 'property-new-dialog' : 'new-entity-dialog'
  }

  head() {
    return {
      title: 'Registries'
    }
  }

  async fetch({ store }) {
    await store.dispatch('types/getTypes')
  }
}
</script>