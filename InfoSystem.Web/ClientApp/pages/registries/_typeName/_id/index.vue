<template>
  <grid :items="properties" :headers="headers" :gridRow="`property-grid-row`" />
</template>

<script>
import { Component, Vue } from 'nuxt-property-decorator'
import { mapState, mapActions } from 'vuex'
import Grid from '~/components/grid.vue'
import { getModule } from 'vuex-module-decorators'
import properties from '@/store/properties'
import entities from '@/store/entities'

@Component({
  components: {
    Grid
  },
  name: 'Entity'
})
export default class extends Vue {
  propertyStore = getModule(properties, this.$store)
  entityStore = getModule(entities, this.$store)

  headers = [
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

  validate({ params }) {
    return !isNaN(+params.id)
  }

  head() {
    return {
      title: `${this.$route.params.typeName.charAt(0).toUpperCase()}${this.$route.params.typeName.slice(1)}s - ${
        this.entityStore.CurrentEntityDisplay
      } | InfoSystem`
    }
  }

  async fetch({ store, params }) {
    await store.dispatch('types/getTypes')
    await store.dispatch('entities/getCurrentEntityDisplay', { Id: params.id, TypeName: params.typeName })
    await store.dispatch('entities/getEntities', params.typeName)
    await store.dispatch('properties/getProperties', { Id: params.id, TypeName: params.typeName })
  }
}
</script>
