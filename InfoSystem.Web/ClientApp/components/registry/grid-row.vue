<template>
  <nuxt-link :to="`${$route.params.typeName}/${item.id}`" tag="tr" style="cursor:pointer">
    <td>{{ item.display }}</td>
    <delete-dialog :remove="remove" />
  </nuxt-link>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import entities from '@/store/entities'

import DeleteDialog from '~/components/delete-dialog.vue'

import { Entity } from '../../models/entity'

@Component({
  name: 'RegistryGridRow',
  components: {
    DeleteDialog
  }
})
export default class extends Vue {
  entitiesStore = getModule(entities, this.$store)

  @Prop() readonly item!: Entity

  remove() {
    this.entitiesStore.deleteEntity(this.item)
  }
}
</script>
