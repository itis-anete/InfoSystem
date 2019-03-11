<template>
  <v-edit-dialog lazy persistent ref="newTypeDialog">
    <v-btn small flat outline icon color="primary">
      <v-icon>add</v-icon>
    </v-btn>
    <template v-slot:input>
      <v-text-field v-model="typeName" class="mt-4" label="Type Name"></v-text-field>
      <v-text-field v-model="identificator" label="Identificator"></v-text-field>
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  data() {
    return {
      typeName: '',
      identificator: ''
    }
  },
  methods: {
    ...mapActions(['addType']),
    create() {
      const type = {
        typeName: this.typeName,
        identificator: this.identificator
      }
      this.addType(type)
      this.clear()
    },
    clear() {
      this.typeName = ''
      this.identificator = ''
      this.$refs['newTypeDialog'].isActive = false
    }
  }
}
</script>
