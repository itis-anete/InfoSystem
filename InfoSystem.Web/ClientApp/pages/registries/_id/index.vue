<template>
  <v-container class="ma-0" style="margin-left: 250px !important">
    <v-layout justify-center>
      <v-flex xs12>
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
  validate({ params }) {
    return !isNaN(+params.id)
  },
  components: {
    RegistryGrid,
    RegistryToolbar
  },
  computed: {
    ...mapGetters(['entities'])
  },
  async fetch({ store, params }) {
    console.log(1)
    await store.dispatch('getEntities', params.id)
    console.log(2)
    await store.dispatch('getTypes')
    console.log(3)
  }
}
</script>
