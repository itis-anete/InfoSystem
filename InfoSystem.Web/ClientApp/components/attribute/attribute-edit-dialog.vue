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
    ...mapActions(['editValue']),
    save() {
      const attribute = {
        id: this.item.id,
        key: this.item.key,
        value: this.value,
        entityId: this.item.entityId,
        typeId: this.item.typeId
      }
      //this.editValue(attribute)
    },
    cancel() {
      this.value = this.item.value
    }
  }
}
</script>
