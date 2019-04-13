<template>
  <v-container class="ma-0 pa-0" style="margin-left: 250px !important; max-width: 100%">
    <v-layout justify-center>
      <v-flex xs12>
        <registry-toolbar></registry-toolbar>
        <v-layout justify-center class="mt-0">
          <v-flex xs11>
            <registry-grid :entities="entities.entities"></registry-grid>
          </v-flex>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapActions, mapState } from 'vuex'
import RegistryGrid from '~/components/registry/grid.vue'
import RegistryToolbar from '~/components/registry/toolbar.vue'
export default {
  name: 'Registry',
  components: {
    RegistryGrid,
    RegistryToolbar
  },
  transition: {
    mode: 'out-in'
  },
  computed: {
    ...mapState(['entities'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
    await store.dispatch('getEntities', params.typeName)
    await store.dispatch('loadHeaders', params)
  }
}
</script>
