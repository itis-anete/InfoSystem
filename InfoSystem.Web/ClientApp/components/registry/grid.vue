<template>
  <v-data-table :headers="grid.headers" :items="entities" :rows-per-page-items="grid.rowsPerPageItems" :pagination.sync="currentPagination">
    <template v-slot:items="props">
      <nuxt-link :to="`${$route.params.typeName}/${props.item.id}`" tag="tr" style="cursor:pointer">
        <td>{{ props.item.display }}</td>
        <registry-delete-dialog :item="props.item" />
      </nuxt-link>
    </template>
  </v-data-table>
</template>

<script>
import RegistryDeleteDialog from '~/components/registry/delete-dialog.vue'
import axios from 'axios'
import { mapState, mapActions } from 'vuex'
export default {
  props: ['entities'],
  components: {
    RegistryDeleteDialog
  },
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
  }
}
</script>

<style scoped>
tbody tr:nth-of-type(even) {
  background-color: #f4f6f9;
}
</style>

