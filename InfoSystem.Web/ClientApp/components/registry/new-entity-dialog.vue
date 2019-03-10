<template>
  <v-edit-dialog lazy persistent ref="newEntityDialog">
    <v-btn color="primary" flat>
      <v-icon class="mr-2">add</v-icon>Create
    </v-btn>
    <template v-slot:input>
      <v-text-field class="mt-4" v-model="identificator" label="Identificator"></v-text-field>
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  data() {
    return {
      identificator: ''
    }
  },
  computed: {
    ...mapGetters(['types'])
  },
  methods: {
    ...mapActions(['addEntity']),
    create() {
      const entity = {
        typeName: this.types.find(x => x.id == this.$route.params.id).name,
        identificator: this.identificator
      }
      this.addEntity(entity)
      this.identificator = ''
      this.$refs['newEntityDialog'].isActive = false
    },
    clear() {
      this.identificator = ''
      this.$refs['newEntityDialog'].isActive = false
    }
  }
}
</script>

<style scoped>

</style>