<template>
  <grid :items="properties.properties" :headers="headers" :gridRow="`property-grid-row`" />
</template>

<script>
import { mapState, mapActions } from 'vuex'
import Grid from '~/components/grid.vue'

export default {
  name: 'Entity',
  components: {
    Grid
  },
  validate({ params }) {
    return !isNaN(+params.id)
  },
  head() {
    return {
      title: `${this.$route.params.typeName.charAt(0).toUpperCase()}${this.$route.params.typeName.slice(1)}s - ${
        this.entities.currentEntityDisplay
      } | InfoSystem`
    }
  },
  data: () => ({
    ent: [],
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
    ...mapState(['properties', 'entities'])
  },
  async fetch({ store, params }) {
    await store.dispatch('getTypes')
    await store.dispatch('getCurrentEntityDisplay', { entityId: params.id, typeName: params.typeName })
    await store.dispatch('getEntities', params.typeName)
    await store.dispatch('getProperties', { entityId: params.id, typeName: params.typeName })
  }
}
</script>
