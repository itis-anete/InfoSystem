<template>
  <grid :items="properties.properties" :headers="headers" :gridRow="`property-grid-row`"></grid>
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
