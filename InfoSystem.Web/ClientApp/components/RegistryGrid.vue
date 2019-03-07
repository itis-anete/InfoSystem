<template>
  <div>
    <edit-entity :dialog.sync="dialog"></edit-entity>
    <v-toolbar flat color="white">
      <v-spacer></v-spacer>
      <template>
        <v-btn color="primary" dark class="ma-3">New Item</v-btn>
      </template>
    </v-toolbar>
    <v-data-table :headers="headers" :items="items" class="elevation-1">
      <template v-slot:items="props">
        <td>{{ props.item.id }}</td>
        <td class="justify-end layout px-4">
          <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          <v-icon small @click="deleteItem(props.item)">delete</v-icon>
        </td>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import EditEntity from './EditEntity.vue'
export default {
  props: ['headers', 'items'],
  components: {
    EditEntity
  },
  data: () => ({
    dialog: false
  }),
  methods: {
    editItem(item) {
      this.dialog = true
      this.$store.dispatch('getValues', { entityId: item.id, typeId: item.typeId })
    },

    deleteItem(item) {}
  }
}
</script>