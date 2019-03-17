<template>
  <v-data-table
    :headers="headers"
    :items="entities"
    :loading="loading"
    :rows-per-page-items="rowsPerPageItems"
    :pagination.sync="pagination"
  >
    <template v-slot:items="props">
      <nuxt-link :to="`${$route.params.typeName}/${props.item.id}`" tag="tr" style="cursor:pointer">
        <td>{{ props.item.id }}</td>
        <td class="justify-end layout px-4">
          <v-icon small @click="deleteItem(props.item)">delete</v-icon>
        </td>
      </nuxt-link>
    </template>
  </v-data-table>
</template>

<script>
import AttributeGrid from '~/components/attribute/grid.vue'
import { mapGetters } from 'vuex'
export default {
  props: ['entities'],
  components: {
    AttributeGrid
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
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>
