<template>
  <v-data-table
    :headers="headers"
    :items="properties"
    :rows-per-page-items="grid.rowsPerPageItems"
    :pagination.sync="currentPagination"
    prev-icon="arrow-left"
    next-icon="arrow-right"
    sort-icon="arrow_drop_down"
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

<style scoped>
.link {
  cursor: pointer !important;
}
tbody tr:nth-of-type(even) {
  background-color: #f4f6f9;
}
</style>