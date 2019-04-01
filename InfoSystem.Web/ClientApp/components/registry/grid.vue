<template>
  <v-data-table
    :headers="headers"
    :items="entities"
    :rows-per-page-items="rowsPerPageItems"
    :pagination.sync="pagination"
  >
    <template v-slot:items="props">
      <nuxt-link :to="`${$route.params.typeName}/${props.item.id}`" tag="tr" style="cursor:pointer">
        <td>{{ props.item.id }}</td>
        <registry-delete-dialog :item="props.item"/>
      </nuxt-link>
    </template>
  </v-data-table>
</template>

<script>
import RegistryDeleteDialog from '~/components/registry/delete-dialog.vue'
export default {
  props: ['entities'],
  components: {
    RegistryDeleteDialog
  },
  data: () => ({
    headers: [{ text: 'Id', sortable: false }, { text: '', sortable: false }],
    rowsPerPageItems: [10, 20, 100, { text: '$vuetify.dataIterator.rowsPerPageAll', value: -1 }],
    pagination: {
      rowsPerPage: 10
    }
  }),
  methods: {
    deleteItem(item) {}
  }
}
</script>

<style scoped>
tbody tr:nth-of-type(even) {
   background-color: #F4F6F9;
 }
</style>

