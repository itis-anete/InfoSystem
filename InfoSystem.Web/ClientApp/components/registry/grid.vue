<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="items"
      sort-icon="mdi-menu-down"
      :loading="loading"
      class="elevation-1"
      :rows-per-page-items="rowsPerPageItems"
      :pagination.sync="pagination"
    >
      <template v-slot:items="props">
        <td>{{ props.item.id }}</td>
        <td class="justify-end layout px-4">
          <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          <v-icon small @click="deleteItem(props.item)">delete</v-icon>
        </td>
      </template>
    </v-data-table>
    <edit-entity-dialog :entityId="entityId" :dialogActive.sync="dialogActive"></edit-entity-dialog>
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
    dialogActive: false,
    rowsPerPageItems: [10, 20, 100, { text: '$vuetify.dataIterator.rowsPerPageAll', value: -1 }],
    pagination: {
      rowsPerPage: 10
    },
    entityId: null
  }),
  methods: {
    editItem(item) {
      this.$store.dispatch('getValues', item.id)
      this.$store.dispatch('getAttributes', item.typeId)
      this.entityId = item.id
      this.dialogActive = true
    },
    deleteItem(item) {}
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>