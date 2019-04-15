<template>
  <v-layout align-center justify-space-between>
    <v-flex xs5> <v-select :items="types.types" return-object item-text="name" v-model="type" label="Key"></v-select> </v-flex>:
    <v-flex xs6>
      <v-select v-if="type" :items="entities.entities" return-object item-text="display" v-model="entity" label="Value"></v-select>
    </v-flex>
  </v-layout>
</template>

<script>
import { mapState } from 'vuex'

export default {
  props: ['propertyKey', 'propertyValue'],
  watch: {
    type(value) {
      if (value) {
        this.$store.dispatch('getEntities', value.name)
      }
    }
  },
  computed: {
    ...mapState(['types', 'entities']),
    type: {
      get() {
        return this.propertyKey
      },
      set(val) {
        this.$emit('update:propertyKey', val)
      }
    },
    entity: {
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
