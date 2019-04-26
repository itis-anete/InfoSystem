<template>
  <v-data-table
    :headers="headers"
    :items="items"
    :rows-per-page-items="rowsPerPageItems"
    :pagination.sync="currentPagination"
    class="fixed-header v-table__overflow table "
    style="max-height: calc(100vh - 130px);backface-visibility: hidden;"
  >
    <template v-slot:items="props">
      <component :is="gridRow" :item="props.item" />
    </template>
  </v-data-table>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

import grid from '@/store/grid'
import { getModule } from 'vuex-module-decorators'

import RegistryGridRow from '~/components/registry/grid-row.vue'
import PropertyGridRow from '~/components/property/grid-row.vue'

import { Entity } from '../models/entity'
import { Property } from '../models/property'
import { Header } from '../models/header'

@Component({
  name: 'Grid',
  components: {
    RegistryGridRow,
    PropertyGridRow
  }
})
export default class extends Vue {
  gridStore = getModule(grid, this.$store)

  @Prop() readonly items!: Entity[] | Property[]
  @Prop() readonly headers!: Header[]
  @Prop(String) readonly gridRow!: string

  get rowsPerPageItems() {
    return this.gridStore.RowsPerPageItems
  }

  get currentPagination() {
    return this.gridStore.Pagination
  }
  set currentPagination(value) {
    this.gridStore.setPagination(value)
  }
}
</script>

<style>
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