<template>
  <v-container class="ma-0 pa-0" style="margin-left: 250px !important; max-width: 100%">
    <v-layout justify-center>
      <v-flex xs12>
        <toolbar :newDialog="`new-entity-dialog`"></toolbar>
        <v-layout justify-center class="mt-0">
          <v-flex xs11>
            <grid :items="entities.entities" :headers="grid.headers" :gridRow="`registry-grid-row`"></grid>
          </v-flex>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapActions, mapState } from 'vuex'
import Grid from '~/components/grid.vue'
import Toolbar from '~/components/toolbar.vue'
export default {
  name: 'Registry',
  components: {
    Grid,
    Toolbar
  },
  computed: {
    ...mapState(['entities', 'grid'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
    await store.dispatch('getEntities', params.typeName)
    await store.dispatch('loadHeaders', params)
  }
}
</script>
