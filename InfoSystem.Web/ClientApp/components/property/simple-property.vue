<template>
  <v-layout align-center justify-space-between>
    <v-flex xs5> <v-text-field label="Key" v-model="propKey"></v-text-field> </v-flex>:
    <v-flex xs6>
      <v-text-field label="Value" v-model="propValue"></v-text-field>
    </v-flex>
  </v-layout>
</template>

<script>
import axios from 'axios'
export default {
  props: ['propertyKey', 'propertyValue'],
  computed: {
    propKey: {
      get() {
        return this.propertyKey
      },
      set(val) {
        this.$emit('update:propertyKey', val)
      }
    },
    propValue: {
      get() {
        return this.propertyValue
      },
      set(val) {
        this.$emit('update:propertyValue', val)
      }
    }
  }
}
</script>

<style>
</style>
