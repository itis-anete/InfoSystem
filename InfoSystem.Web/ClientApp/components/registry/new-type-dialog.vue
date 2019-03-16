<template>
  <v-edit-dialog lazy persistent ref="newTypeDialog">
    <v-btn small flat outline icon color="primary">
      <v-icon>add</v-icon>
    </v-btn>
    <template v-slot:input>
      <v-text-field v-model="typeName" class="mt-4" label="Type Name"></v-text-field>
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  data: () => ({
    typeName: ''
  }),
  methods: {
    ...mapActions(['addType']),
    create() {
      this.addType(this.typeName)
      this.clear()
    },
    clear() {
      this.typeName = ''
      this.$refs['newTypeDialog'].isActive = false
    }
  }
}
</script>
