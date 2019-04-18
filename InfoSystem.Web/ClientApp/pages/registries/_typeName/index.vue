<template>
  <grid :items="entities" :headers="headers" :gridRow="`registry-grid-row`" />
</template>

<script>
import Grid from '~/components/grid.vue'

import { Component, Vue } from 'nuxt-property-decorator'
import entities from '@/store/entities'
import { getModule } from 'vuex-module-decorators'

@Component({
  components: {
    Grid
  },
  name: 'Registry'
})
export default class extends Vue {
  entitiesStore = getModule(entities, this.$store)

  get entities() {
    return this.entitiesStore.Entities
  }

  headers = [
    {
      text: 'Key',
      align: 'left',
      value: 'key'
    },
    { text: '', sortable: false }
  ]

  head() {
    return {
      title: `${this.$route.params.typeName.charAt(0).toUpperCase()}${this.$route.params.typeName.slice(
        1
      )}s  | InfoSystem`
    }
  }

  async fetch({ store, params }) {
    await store.dispatch('types/getTypes')
    await store.dispatch('entities/getEntities', params.typeName)
    //await store.dispatch('grid/loadHeaders', params)
  }
}
</script>
