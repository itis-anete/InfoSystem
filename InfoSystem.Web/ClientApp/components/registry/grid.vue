<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="entities"
      :loading="loading"
      :rows-per-page-items="rowsPerPageItems"
      :pagination.sync="pagination"
    >
      <template v-slot:items="props">
        <tr @click.stop="expand(props)" style="cursor: pointer">
          <td>{{ props.item.id }}</td>
          <td class="justify-end layout px-4">
            <v-icon small @click="deleteItem(props.item)">delete</v-icon>
            <v-icon :class="{rotated:props.expanded}">arrow_drop_down</v-icon>
          </td>
        </tr>
      </template>
      <template v-slot:expand="props">
        <v-container :class="{expanded:props.expanded}">
          <v-layout justify-end>
            <v-flex xs12>
              <attribute-grid :items="attributes"></attribute-grid>
            </v-flex>
          </v-layout>
        </v-container>
      </template>
    </v-data-table>
  </div>
</template>

<script>
import axios from 'axios'
import AttributeGrid from '~/components/attribute/grid.vue'
import { mapGetters, mapActions } from 'vuex'
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
    },
    attributes: []
  }),
  methods: {
    ...mapActions(['getAttributes']),
    deleteItem(item) {},
    async expand(props) {
      if (!props.expanded) {
        this.attributes = await this.getAttributes({ id: props.item.id, typeId: props.item.typeId })
      }
      props.expanded = !props.expanded
    }
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>

<style scoped>
.expanded{
	border-bottom: 1px solid rgba(0,0,0,0.12)
}
.rotated{
	transition: transform 0.2s;
	transform: rotate(180deg);
}
</style>