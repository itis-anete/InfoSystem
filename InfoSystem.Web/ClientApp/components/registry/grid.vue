<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="entities"
      sort-icon="mdi-menu-down"
      :loading="loading"
      class="elevation-1"
      :rows-per-page-items="rowsPerPageItems"
      :pagination.sync="pagination"
    >
      <template v-slot:items="props">
        <tr @click="onExpand(props)">
          <td>{{ props.item.id }}</td>
          <td class="justify-end layout px-4">
            <v-icon small @click="deleteItem(props.item)">delete</v-icon>
            <v-icon v-if="!props.expanded">arrow_drop_down</v-icon>
            <v-icon v-else>arrow_drop_up</v-icon>
          </td>
        </tr>
      </template>
      <template v-slot:expand="props">
        <v-layout justify-end>
          <v-flex v-if="!loading" xs10>
            <dialog-grid></dialog-grid>
          </v-flex>
        </v-layout>
      </template>
    </v-data-table>
    <edit-entity-dialog :dialogActive.sync="dialogActive"></edit-entity-dialog>
  </div>
</template>

<script>
import EditEntityDialog from '~/components/edit-entity/dialog.vue'
import DialogGrid from '~/components/edit-entity/dialog-grid.vue'
import { mapGetters } from 'vuex'
export default {
  props: ['headers', 'entities'],
  components: {
    EditEntityDialog,
    DialogGrid
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
      this.$store.dispatch('getAttributes', { entityId: item.id, typeId: this.$route.params.id })
      this.dialogActive = true
    },
    deleteItem(item) {},
    onExpand(props) {
      props.expanded = !props.expanded
      this.$store.dispatch('getAttributes', { entityId: props.item.id, typeId: props.item.typeId })
    }
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>