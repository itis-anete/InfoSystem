<template>
  <grid :items="entities" :headers="headers" :gridRow="`registry-grid-row`" />
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import entities from '@/store/entities'
import grid from '@/store/grid'

import Grid from '~/components/grid.vue'

@Component({
  name: 'Registry',
  components: {
    Grid
  },
  async fetch({ store, params }) {
    await store.dispatch('types/getTypes')
    await store.dispatch('entities/getEntities', params.typeName)
    await store.dispatch('grid/loadHeaders', params.typeName)
  },
  head() {
    return { title: `${this.$route.params.typeName.charAt(0).toUpperCase()}${this.$route.params.typeName.slice(1)}s` }
  }
})
export default class extends Vue {
  entitiesStore = getModule(entities, this.$store)
  gridStore = getModule(grid, this.$store)

  get entities() {
    return this.entitiesStore.Entities
  }
  get headers() {
    return this.gridStore.Headers
  }
}
</script>
