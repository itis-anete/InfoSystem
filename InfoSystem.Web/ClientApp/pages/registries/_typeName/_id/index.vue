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
  propertiesStore = getModule(properties, this.$store)
  entitiesStore = getModule(entities, this.$store)

  headers: Header[] = [
    { text: 'Key', align: 'left', value: 'key', sortable: false },
    { text: 'Value', sortable: false, align: 'left', value: 'value' },
    { text: '', sortable: false, align: 'right', value: '' }
  ]

  get properties() {
    return this.propertiesStore.Properties
  }

  head() {
    return { title: `${this.entitiesStore.CurrentEntityDisplay}` }
  }

  validate({ params }) {
    return !isNaN(+params.id)
  }
}
</script>
