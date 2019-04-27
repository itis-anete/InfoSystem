<template>
  <v-layout align-center justify-space-between>
    <v-flex xs5>
      <v-text-field label="Key" v-model="propKey" />
    </v-flex>
    {{ `:` }}
    <v-flex xs6>
      <v-text-field label="Value" v-model="propValue" />
    </v-flex>
  </v-layout>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

@Component({
  name: 'SimpleProperty'
})
export default class extends Vue {
  @Prop({ default: '' }) readonly propertyKey!: string
  @Prop({ default: '' }) readonly propertyValue!: string

  get propKey() {
    return this.propertyKey
  }
  set propKey(val) {
    this.$emit('update:propertyKey', val)
  }

  get propValue() {
    return this.propertyValue
  }
  set propValue(val) {
    this.$emit('update:propertyValue', val)
  }
}
</script>