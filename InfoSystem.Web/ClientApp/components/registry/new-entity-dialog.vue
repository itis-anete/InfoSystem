<template>
  <v-edit-dialog lazy persistent ref="newEntityDialog">
    <v-btn color="primary" flat>
      <v-icon class="mr-2">add</v-icon>Create
    </v-btn>
    <template v-slot:input>
      <v-text-field
        v-model="requiredAttributeValue"
        class="mt-4"
        :label="`Value of ${requiredProperty}`"
      ></v-text-field>
      <v-btn color="error" flat @click="clear">Cancel</v-btn>
      <v-btn color="primary" flat @click="create">Create</v-btn>
    </template>
  </v-edit-dialog>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
export default {
  data: () => ({
    requiredAttributeValue: ''
  }),
  computed: {
    ...mapGetters(['types']),
    requiredProperty() {
      return this.types.find(x => x.name == this.$route.params.typeName).requiredProperty
    }
  },
  methods: {
    ...mapActions(['addEntity']),
    create() {
      this.addEntity({ typeName: this.$route.params.typeName, requiredAttributeValue: this.requiredAttributeValue })
      this.clear()
    },
    clear() {
      this.requiredAttributeValue = ''
      this.$refs['newEntityDialog'].isActive = false
    }
  }
}
</script>
