<template>
  <v-data-table
    :headers="headers"
    :items="properties"
    :rows-per-page-items="rowsPerPageItems"
    :pagination.sync="pagination"
    prev-icon="arrow-left"
    next-icon="arrow-right"
    sort-icon="arrow_drop_down"
  >
    <template v-slot:items="props">
      <tr @click="linkTo(props.item)" :key="props.index" :class="{link : props.item.isComplex}">
        <td>{{props.item.key}}</td>
        <td v-if="props.item.isComplex">{{props.item.value}}</td>
        <property-edit-dialog v-else :item="props.item"/>
        <property-delete-dialog :item="props.item"/>
      </tr>
    </template>
  </v-data-table>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
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
    ],
    rowsPerPageItems: [10, 20, 100, { text: '$vuetify.dataIterator.rowsPerPageAll', value: -1 }],
    pagination: {
      rowsPerPage: 10
    }
  }),
  methods: {
    linkTo(item) {
      if (item.isComplex) this.$router.push(`../${item.key.substring(8)}/${item.value}`)
    }
  }
}
</script>

<style scoped>
.link {
  cursor: pointer !important;
}
tbody tr:nth-of-type(even) {
   background-color: #F4F6F9;
 }
</style>