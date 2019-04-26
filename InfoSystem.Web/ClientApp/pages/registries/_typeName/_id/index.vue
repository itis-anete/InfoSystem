<template>
  <grid :items="properties" :headers="headers" :gridRow="`property-grid-row`" />
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import properties from '@/store/properties'
import entities from '@/store/entities'

import Grid from '@/components/grid.vue'

import { Header } from '@/models/header'

@Component({
  name: 'Entity',
  components: {
    Grid
  },
  async fetch({ store, params }) {
    await store.dispatch('types/getTypes')
    await store.dispatch('entities/getCurrentEntityDisplay', { id: params.id, typeName: params.typeName })
    await store.dispatch('entities/getEntities', params.typeName)
    await store.dispatch('properties/getProperties', { id: params.id, typeName: params.typeName })
  }
})
export default class extends Vue {
  propertyStore = getModule(properties, this.$store)
  entityStore = getModule(entities, this.$store)

  headers: Header[] = [
    {
      text: 'Key',
      align: 'left',
      value: 'key'
    },
    { text: 'Value', sortable: false },
    { text: '', sortable: false }
  ]

  get properties() {
    return this.propertyStore.Properties
  }

  head() {
    return { title: `${this.entityStore.CurrentEntityDisplay}` }
  }

  validate({ params }) {
    return !isNaN(+params.id)
  }
}
</script>
