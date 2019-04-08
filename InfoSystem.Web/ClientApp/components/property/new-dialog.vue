<template>
  <v-dialog v-model="dialog" persistent max-width="500">
    <template v-slot:activator="{ on }">
      <v-btn color="primary" flat v-on="on"> <v-icon class="mr-2">add</v-icon>Add </v-btn>
    </template>
    <v-card>
      <v-card-title class="headline">Add property</v-card-title>
      <v-card-text>
        <v-switch v-model="complex" color="primary" :label="`${complex ? 'Complex' : 'Simple'}`"></v-switch>
        <component :is="view" :propertyKey.sync="property.key" :propertyValue.sync="property.value"></component>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn color="error" flat @click="clear">Cancel</v-btn>
        <v-btn color="primary" flat @click="add">Add</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import Complex from '../property/complex-property.vue'
import Simple from '../property/simple-property.vue'

import axios from 'axios'
import { mapActions, mapState } from 'vuex'
export default {
  components: {
    Complex,
    Simple
  },
  data: () => ({
    dialog: false,
    complex: false,
    property: {
      key: '',
      value: '',
      typeId: '',
      entityId: ''
    }
  }),
  computed: {
    ...mapState(['types', 'entities']),
    view() {
      return this.complex ? 'complex' : 'simple'
    }
  },
  methods: {
    ...mapActions(['addProperty']),
    async add() {
      this.property.typeId = this.types.types.find(x => x.name == this.$route.params.typeName).id
      this.property.entityId = this.$route.params.id
      if (this.complex) {
        this.property.key = `Complex:${this.property.key.name}`
        this.property.value = this.property.value.id
      }
      await this.addProperty(this.property)
      this.clear()
    },
    clear() {
      this.property.key = ''
      this.property.value = ''
      this.complex = false
      this.dialog = false
    }
  }
}
</script>
