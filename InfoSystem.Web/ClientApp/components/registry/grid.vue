<template>
  <div>
    <edit-entity-dialog :dialogActive.sync="dialogActive"></edit-entity-dialog>
    <v-toolbar flat color="white">
      <v-spacer></v-spacer>
      <template>
        <v-btn color="primary" dark class="ma-3">
          <v-icon class="mr-2">add</v-icon>Add
        </v-btn>
      </template>
    </v-toolbar>
    <v-data-table :loading="loading" :headers="headers" :items="items" class="elevation-1">
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
import EditEntityDialog from '~/components/edit-entity/dialog.vue'
import { mapGetters } from 'vuex'
export default {
  props: ['headers', 'items'],
  components: {
    EditEntityDialog
  },
  data: () => ({
    dialogActive: false
  }),
  methods: {
    editItem(item) {
      this.dialogActive = true
      this.$store.dispatch('getValues', { entityId: item.id, typeId: item.typeId })
      this.$store.dispatch('getAttributes', item.typeId)
    },
    deleteItem(item) {}
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>