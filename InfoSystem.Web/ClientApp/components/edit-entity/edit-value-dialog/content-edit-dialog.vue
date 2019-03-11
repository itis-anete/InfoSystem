<template>
  <td>
    <v-edit-dialog large lazy persistent @save="save" @cancel="cancel">
      <div>{{ content }}</div>
      <template v-slot:input>
        <v-text-field v-model="content" label="Value" single-line counter autofocus></v-text-field>
      </template>
    </v-edit-dialog>
  </td>
</template>

<script>
export default {
  props: ['item'],
  data() {
    return {
      content: this.item.content
    }
  },
  methods: {
    save() {
      this.$emit('update:content', this.content)
    },
    cancel() {
      this.content = this.item.content
    }
  }
}
</script>
