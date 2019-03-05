<template>
  <div>
    <v-toolbar flat color="white">
      <v-spacer></v-spacer>
      <template>
        <v-btn color="primary" dark class="mb-2" v-on="on">New Item</v-btn>
      </template>
      <edit-entity :dialog="dialog" @dialogChange="dialog = $event"></edit-entity>
    </v-toolbar>
    <v-data-table :headers="headers" :items="items" class="elevation-1">
      <template v-slot:items="props">
        <td v-for="key in Object.keys(props.item)">{{ props.item[key] }}</td>
        <td class="justify-center layout px-0">
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