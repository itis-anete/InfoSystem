<template>
  <td>
    <v-edit-dialog large lazy persistent @save="save" @cancel="cancel">
      <div>{{ value }}</div>
      <template v-slot:input>
        <v-text-field v-model="value" label="Value" single-line counter autofocus></v-text-field>
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
    },
    cancel() {
      this.value = this.item.value
    }
  }
}
</script>
