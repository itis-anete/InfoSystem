<template>
  <v-container class="ma-0" style="margin-left: 250px !important">
    <v-layout justify-center>
      <v-flex xs10>
<<<<<<< HEAD
        <v-card v-if="properties">
          <toolbar></toolbar>
          <property-grid :properties="properties"></property-grid>
=======
        <v-card v-if="properties.properties">
          <entity-toolbar></entity-toolbar>
          <property-grid :properties="properties.properties"></property-grid>
>>>>>>> origin/master
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
<<<<<<< HEAD
import { mapGetters, mapActions } from 'vuex'
import Toolbar from '~/components/property/toolbar.vue'
=======
import { mapState, mapActions } from 'vuex'
import EntityToolbar from '~/components/entity-toolbar.vue'
>>>>>>> origin/master
import PropertyGrid from '~/components/property/grid.vue'
export default {
  name: 'Entity',
  validate({ params }) {
    return !isNaN(+params.id)
  },
  components: {
    PropertyGrid,
    Toolbar
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
