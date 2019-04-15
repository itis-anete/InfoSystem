<template>
  <grid :items="entities.entities" :headers="grid.headers" :gridRow="`registry-grid-row`" />
</template>

<script>
import { mapActions, mapState } from 'vuex'
import Grid from '~/components/grid.vue'
export default {
  name: 'Registry',
  components: {
    Grid
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
