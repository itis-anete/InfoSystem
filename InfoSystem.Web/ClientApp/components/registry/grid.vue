<template>
  <div>
    <v-toolbar card color="secondary">
      <v-toolbar-items>
        <v-btn flat>
          <v-icon class="mr-2">add</v-icon>Add
        </v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <v-data-table :loading="loading" :headers="headers" :items="items" class="elevation-1">
      <template v-slot:items="props">
        <td>{{ props.item.id }}</td>
        <td class="justify-end layout px-4">
          <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          <v-icon small @click="deleteItem(props.item)">delete</v-icon>
        </td>
        <edit-entity-dialog :entity="props.item" :dialogActive.sync="dialogActive"></edit-entity-dialog>
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
      this.$store.dispatch('getValues', item.id)
      this.$store.dispatch('getAttributes', item.typeId)
      this.dialogActive = true
    },
    deleteItem(item) {}
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>