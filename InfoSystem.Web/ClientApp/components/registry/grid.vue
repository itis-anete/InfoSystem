<template>
  <v-data-table
    :headers="headers"
    :items="entities"
    :rows-per-page-items="rowsPerPageItems"
    :pagination.sync="pagination"
  >
    <template v-slot:items="props">
      <nuxt-link :to="`${$route.params.typeName}/${props.item.id}`" tag="tr" style="cursor:pointer">
        <td>{{props.item.display}}</td>
        <registry-delete-dialog :item="props.item"/>
      </nuxt-link>
    </template>
  </v-data-table>
</template>

<script>
import RegistryDeleteDialog from '~/components/registry/delete-dialog.vue'
import axios from 'axios'
import { mapGetters, mapActions } from 'vuex'
export default {
  props: ['entities'],
  components: {
    RegistryDeleteDialog
  },
  data: () => ({
    rowsPerPageItems: [10, 20, 100, { text: '$vuetify.dataIterator.rowsPerPageAll', value: -1 }],
    pagination: {
      rowsPerPage: 10
    }
  }),
  computed: {
    ...mapGetters(['headers'])
  }
}
</script>

<style scoped>
tbody tr:nth-of-type(even) {
  background-color: #f4f6f9;
}
</style>

