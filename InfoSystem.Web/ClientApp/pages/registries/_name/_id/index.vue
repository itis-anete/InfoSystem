<template>
  <v-container class="ma-0" style="margin-left: 250px !important">
    <v-layout justify-center>
      <v-flex xs10>
        <v-card v-if="attributes">
          <entity-toolbar></entity-toolbar>
          <attribute-grid :attributes="attributes"></attribute-grid>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import EntityToolbar from '~/components/entity-toolbar.vue'
import AttributeGrid from '~/components/attribute/grid.vue'
export default {
  name: 'Entity',
  validate({ params }) {
    return !isNaN(+params.id)
  },
  components: {
    AttributeGrid,
    EntityToolbar
  },
  computed: {
    ...mapGetters(['attributes'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
    await store.dispatch('getAttributes', { entityId: params.id, typeName: params.name })
  }
}
</script>
