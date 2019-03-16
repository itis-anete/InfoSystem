<template>
  <v-edit-dialog lazy persistent ref="newEntityDialog">
    <v-btn color="primary" flat>
      <v-icon class="mr-2">add</v-icon>Create
    </v-btn>
    <template v-slot:input>
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  computed: {
    ...mapGetters(['types'])
  },
  methods: {
    ...mapActions(['addEntity']),
    create() {
      this.addEntity(this.types.find(x => x.id == this.$route.params.id).name)
      this.clear()
    },
    clear() {
      this.identificator = ''
      this.$refs['newEntityDialog'].isActive = false
    }
  }
}
</script>
