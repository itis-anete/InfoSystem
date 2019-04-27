<template>
  <td>
    <v-edit-dialog lazy persistent ref="propertyEditDialog">
      <div>{{ item.value }}</div>
      <template v-slot:input>
        <v-text-field v-model="value" label="Value" single-line counter autofocus />
        <v-btn color="error" flat @click="cancel">Cancel</v-btn>
        <v-btn color="primary" flat @click="save">save</v-btn>
      </template>
    </v-edit-dialog>
  </td>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import properties from '@/store/properties'

import { Property } from '../../models/property'

@Component({
  name: 'PropertyEditDialog'
})
export default class extends Vue {
  propertiesStore = getModule(properties, this.$store)

  @Prop() readonly item!: Property

  value = this.item.value

  $refs!: {
    propertyEditDialog: any
  }

  save() {
    const property = {
      ...this.item,
      value: this.value
    }
    this.propertiesStore.updateProperty(property)
    this.$refs.propertyEditDialog.isActive = false
  }
  cancel() {
    this.value = this.item.value
    this.$refs.propertyEditDialog.isActive = false
  }
}
</script>
