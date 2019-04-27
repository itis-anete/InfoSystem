<template>
  <v-dialog v-model="dialog" persistent max-width="500">
    <template v-slot:activator="{ on }">
      <v-btn color="primary" depressed v-on="on"> <v-icon class="mr-2">add</v-icon>Add Property </v-btn>
    </template>
    <v-card>
      <v-card-title class="headline">Add new property</v-card-title>
      <v-card-text>
        <v-switch v-model="complex" color="primary" :label="`${complex ? 'Complex' : 'Simple'}`" />
        <component :is="view" :propertyKey.sync="property.key" :propertyValue.sync="property.value" />
      </v-card-text>
      <v-card-actions>
        <v-spacer />
        <v-btn color="error" flat @click="clear">Cancel</v-btn>
        <v-btn color="primary" flat @click="add">Add</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import entities from '@/store/entities'
import types from '@/store/types'
import properties from '@/store/properties'

import Complex from '../property/complex-property.vue'
import Simple from '../property/simple-property.vue'
import { Type } from '../../models/type'
import { Property } from '../../models/property'
import { newProperty } from '../../models/newProperty'
import { Entity } from '../../models/entity'

@Component({
  name: 'PropertyNewDialog',
  components: {
    Complex,
    Simple
  }
})
export default class extends Vue {
  entitiesStore = getModule(entities, this.$store)
  typesStore = getModule(types, this.$store)
  propertiesStore = getModule(properties, this.$store)

  dialog = false

  complex = false

  property: newProperty = {
    key: '',
    value: ''
  }

  get types() {
    return this.typesStore.Types
  }

  get entities() {
    return this.entitiesStore.Entities
  }

  get view() {
    return this.complex ? 'complex' : 'simple'
  }

  get currentType() {
    return this.typesStore.Types.find(x => x.name == this.$route.params.typeName) as Type
  }

  @Watch('complex')
  onComplexChanged() {
    this.property.key = ''
    this.property.value = ''
  }

  async add() {
    let newProp: newProperty = {
      ...this.property,
      typeId: this.currentType.id as number,
      entityId: +this.$route.params.id
    }
    if (this.complex) {
      let key = this.property.key as Type
      let value = this.property.value as Entity
      let id = value.id as number
      newProp.key = `Complex:${key.name}`
      newProp.value = id.toString()
    }
    await this.propertiesStore.addProperty(newProp)
    this.clear()
  }
  clear() {
    this.property.key = ''
    this.property.value = ''
    this.complex = false
    this.dialog = false
  }
}
</script>
