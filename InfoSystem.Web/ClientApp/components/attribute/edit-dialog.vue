<template>
  <td>
    <v-edit-dialog lazy persistent ref="attributeEditDialog">
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
    ...mapActions(['updateAttribute']),
    save() {
      const attribute = {
        attributeId: this.item.id,
        typeName: this.$route.params.typeName,
        newValue: this.value
      }
      this.updateAttribute(attribute)
      this.$refs['attributeEditDialog'].isActive = false
    },
    cancel() {
      this.value = this.item.value
      this.$refs['attributeEditDialog'].isActive = false
    }
  }
}
</script>
