<template>
  <td>
    <v-edit-dialog large lazy persistent @save="save" @cancel="cancel">
      <div>{{ attribute.name }}</div>
      <template v-slot:input>
        <v-select :items="attributes" item-text="name" return-object v-model="attribute"></v-select>
      </template>
    </v-edit-dialog>
  </td>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  props: ['item'],
  data() {
    return {
      attribute: this.item.attribute
    }
  },
  computed: {
    ...mapGetters(['attributes'])
  },
  methods: {
    save() {
      this.$emit('update:attribute', this.attribute)
    },
    cancel() {
      this.attribute = this.item.attribute
    }
  }
}
</script>

<style scoped>

</style>