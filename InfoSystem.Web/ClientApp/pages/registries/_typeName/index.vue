<template>
  <v-container class="ma-0" style="margin-left: 250px !important">
    <v-layout justify-center>
      <v-flex xs10>
        <v-card v-if="entities">
          <registry-toolbar></registry-toolbar>
          <registry-grid :entities="entities"></registry-grid>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
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
    ...mapGetters(['entities'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
    await store.dispatch('getEntities', params.typeName)
  }
}
</script>
