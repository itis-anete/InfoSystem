<template>
  <v-layout align-center justify-space-between>
    <v-flex xs5>
      <v-select :items="types" return-object item-text="name" v-model="type" label="Key" />
    </v-flex>
    {{ `:` }}
    <v-flex xs6>
      <v-select v-if="type" :items="entities" return-object item-text="display" v-model="entity" label="Value" />
    </v-flex>
  </v-layout>
</template>


<script lang="ts">
import { Component, Vue, Prop, Watch } from 'nuxt-property-decorator'

import { getModule } from 'vuex-module-decorators'
import entities from '@/store/entities'
import types from '@/store/types'

import { Type } from '../../models/type'
import { Entity } from '../../models/entity'

@Component({
  name: 'ComplexProperty'
})
export default class extends Vue {
  entitiesStore = getModule(entities, this.$store)
  typesStore = getModule(types, this.$store)

  @Prop() readonly propertyKey!: Type
  @Prop() readonly propertyValue!: Entity

  @Watch('type')
  onTypeChanged(value: Type) {
    if (value) {
      this.entitiesStore.getEntities(value.name)
    }
  }

  get entities() {
    return this.entitiesStore.Entities
  }

  get types() {
    return this.typesStore.Types
  }

  get type() {
    return this.propertyKey
  }
  set type(val) {
    this.$emit('update:propertyKey', val)
  }

  get entity() {
    return this.propertyValue
  }
  set entity(val) {
    this.$emit('update:propertyValue', val)
  }
}
</script>
