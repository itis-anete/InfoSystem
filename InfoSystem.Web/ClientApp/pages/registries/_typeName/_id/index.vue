<template>
  <v-container class="ma-0 pa-0" style="margin-left: 250px !important; max-width: 100%">
    <v-layout justify-center>
      <v-flex xs12>
        <toolbar :newDialog="`property-new-dialog`"></toolbar>
        <v-layout justify-center class="mt-0">
          <v-flex xs11>
            <grid :items="properties.properties" :headers="headers" :gridRow="`property-grid-row`"></grid>
          </v-flex>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import Toolbar from '~/components/toolbar.vue'
import Grid from '~/components/grid.vue'

export default {
  name: 'Entity',
  components: {
    Grid,
    Toolbar
  },
  validate({ params }) {
    return !isNaN(+params.id)
  },
  data: () => ({
    headers: [
      {
        text: 'Key',
        align: 'left',
        value: 'key'
      },
      { text: 'Value', sortable: false },
      { text: '', sortable: false }
    ]
  }),
  computed: {
    ...mapState(['properties'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
    await store.dispatch('getProperties', { entityId: params.id, typeName: params.typeName })
  }
}
</script>
