<template>
  <v-card v-if="entities">
    <registry-grid :headers="headers" :items="entities"></registry-grid>
  </v-card>
</template>

<script>
import { mapGetters } from 'vuex'
import RegistryGrid from '~/components/registry/grid.vue'
export default {
  name: 'Registry',
  validate({ params }) {
    return !isNaN(+params.id)
  },
  components: {
    RegistryGrid
  },
  data: () => ({
    headers: [{ text: 'Id', sortable: false }, { text: '', sortable: false }]
  }),
  computed: {
    ...mapGetters(['entities'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getEntities', params.id)
  }
}
</script>
