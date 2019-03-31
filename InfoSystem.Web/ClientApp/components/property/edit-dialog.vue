<template>
  <td>
    <v-edit-dialog lazy persistent ref="propertyEditDialog">
      <div>{{ item.value }}</div>
      <template v-slot:input>
        <v-text-field v-model="value" label="Value" single-line counter autofocus></v-text-field>
        <v-btn color="error" flat @click="cancel">Cancel</v-btn>
        <v-btn color="primary" flat @click="save">save</v-btn>
      </template>
    </v-edit-dialog>
  </td>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  props: ['item'],
  data() {
    return {
      value: this.item.value
    }
  },
  methods: {
    ...mapActions(['updateProperty']),
    save() {
      const property = {
        propertyId: this.item.id,
        typeName: this.$route.params.typeName,
        newValue: this.value
      }
      this.updateProperty(property)
      this.$refs['propertyEditDialog'].isActive = false
    },
    cancel() {
      this.value = this.item.value
      this.$refs['propertyEditDialog'].isActive = false
    }
  }
}
</script>
