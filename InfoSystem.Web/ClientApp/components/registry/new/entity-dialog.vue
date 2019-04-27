<template>
  <v-edit-dialog lazy persistent ref="newEntityDialog">
    <v-btn color="primary" depressed> <v-icon class="mr-2">add</v-icon>Create Entity</v-btn>
    <template v-slot:input>
      <v-text-field v-model="requiredAttributeValue" class="mt-4" :label="`Value of ${currentType.requiredProperty}`" />
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script lang="ts">
import { Component, Vue } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import types from '@/store/types'
import entities from '@/store/entities'
import { Type } from '../../../models/type'

@Component({
  name: 'NewEntityDialog'
})
export default class extends Vue {
  typesStore = getModule(types, this.$store)
  entitiesStore = getModule(entities, this.$store)

  requiredAttributeValue = ''

  get currentType() {
    return this.typesStore.Types.find(x => x.name == this.$route.params.typeName) as Type
  }

  $refs!: {
    newEntityDialog: any
  }

  create() {
    this.entitiesStore.addEntity({
      typeId: this.currentType.id as number,
      requiredAttributeValue: this.requiredAttributeValue
    })
    this.clear()
  }
  clear() {
    this.requiredAttributeValue = ''
    this.$refs.newEntityDialog.isActive = false
  }
}
</script>
