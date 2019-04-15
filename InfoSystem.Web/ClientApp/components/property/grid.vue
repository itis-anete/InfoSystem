<template>
  <v-data-table
    :headers="headers"
    :items="properties"
    :rows-per-page-items="grid.rowsPerPageItems"
    :pagination.sync="currentPagination"
    class="fixed-header v-table__overflow table "
    style="max-height: calc(100vh - 130px);backface-visibility: hidden;"
  >
    <template v-slot:items="props">
      <tr @click="linkTo(props.item)" :key="props.index" :class="{ link: props.item.isComplex }">
        <td>{{ formatKey(props.item) }}</td>
        <td v-if="props.item.isComplex">{{ props.item.displayComplexValue }}</td>
        <property-edit-dialog v-else :item="props.item" />
        <property-delete-dialog :item="props.item" />
      </tr>
    </template>
  </v-data-table>
</template>

<script>
import { mapState } from 'vuex'
import PropertyEditDialog from '~/components/property/edit-dialog.vue'
import PropertyDeleteDialog from '~/components/property/delete-dialog.vue'
export default {
  name: 'attribute-grid',
  props: ['properties'],
  components: {
    PropertyEditDialog,
    PropertyDeleteDialog
  },
  data: () => ({
    headers: [
      {
        text: 'Key',
        align: 'left',
        value: 'key'
      },
      { text: 'Value', sortable: false },
      { text: '', sortable: false }
    ]
  }),
  computed: {
    ...mapState(['grid']),
    currentPagination: {
      get() {
        return this.grid.pagination
      },
      set(value) {
        this.$store.commit('setPagination', value)
      }
    }
  },
  methods: {
    linkTo(item) {
      if (item.isComplex) this.$router.push(`../${item.key.substring(8)}/${item.value}`)
    },
    formatKey(item) {
      return item.isComplex ? item.key.substring(8) : item.key
    }
  }
}
</script>

<style>
.link {
  cursor: pointer !important;
}
tbody tr:nth-of-type(even) {
  background-color: #f4f6f9;
}
.table {
  border-right: 1px solid rgba(0, 0, 0, 0.12);
  border-left: 1px solid rgba(0, 0, 0, 0.12);
  border-bottom: 1px solid rgba(0, 0, 0, 0.12);
}
.table::-webkit-scrollbar {
  display: none;
}
.theme--light.v-table thead th {
  background-color: #eaeaea;
}
.fixed-header {
  display: flex;
  flex-direction: column;
  height: 100%;
}
.fixed-header table {
  table-layout: fixed;
}
.fixed-header th {
  position: sticky;
  top: 0;
  z-index: 5;
}
.fixed-header th:after {
  content: '';
  position: absolute;
  left: 0;
  bottom: 0;
  width: 100%;
}
.fixed-header tr.v-datatable__progress th {
  height: 1px;
}
.fixed-header .v-table__overflow {
  flex-grow: 1;
  flex-shrink: 1;
  overflow-x: auto;
  overflow-y: auto;
}
.fixed-header .v-datatable.v-table {
  flex-grow: 0;
  flex-shrink: 1;
}
.fixed-header .v-datatable.v-table .v-datatable__actions {
  flex-wrap: nowrap;
}
.fixed-header .v-datatable.v-table .v-datatable__actions .v-datatable__actions__pagination {
  white-space: nowrap;
}
</style>