<template>
  <v-container class="ma-0" style="margin-left: 250px !important">
    <v-layout justify-center>
      <v-flex xs10>
        <v-card v-if="properties.properties">
          <entity-toolbar></entity-toolbar>
          <property-grid :properties="properties.properties"></property-grid>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapState, mapActions } from 'vuex'
import EntityToolbar from '~/components/entity-toolbar.vue'
import PropertyGrid from '~/components/property/grid.vue'
export default {
  name: 'Entity',
  validate({ params }) {
    return !isNaN(+params.id)
  },
  components: {
    PropertyGrid,
    EntityToolbar
  },
  computed: {
    ...mapState(['properties'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
    await store.dispatch('getProperties', { entityId: params.id, typeName: params.typeName })
  }
}
</script>
