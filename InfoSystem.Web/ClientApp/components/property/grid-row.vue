<template>
  <tr @click="linkTo(item)" :class="{ link: item.isComplex }">
    <td>{{ formatKey(item) }}</td>
    <td v-if="item.isComplex">{{ item.displayComplexValue }}</td>
    <property-edit-dialog v-else :item="item" />
    <delete-dialog :remove="remove" />
  </tr>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import properties from '@/store/properties'

import PropertyEditDialog from '~/components/property/edit-dialog.vue'
import DeleteDialog from '~/components/delete-dialog.vue'

import { Property } from '../../models/property'
@Component({
  name: 'PropertyGridRow',
  components: {
    PropertyEditDialog,
    DeleteDialog
  }
})
export default class extends Vue {
  propertiesStore = getModule(properties, this.$store)

  @Prop() readonly item!: Property

  remove() {
    this.propertiesStore.deleteProperty(this.item)
  }
  linkTo(item: Property) {
    if (item.isComplex) this.$router.push(`../${item.key.substring(8)}/${item.value}`)
  }
  formatKey(item: Property) {
    return item.isComplex ? item.key.substring(8) : item.key
  }
}
</script>

<style>
.link {
  cursor: pointer !important;
}
</style>
