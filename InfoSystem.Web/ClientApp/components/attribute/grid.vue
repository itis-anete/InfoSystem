<template>
  <v-data-table
    :headers="headers"
    :items="items"
    item-key="id"
    sort-icon="arrow_drop_down"
    hide-actions
    class="table-borders"
  >
    <template v-slot:headers="props">
      <tr class="table-headers">
        <th
          class="column text-xs-left"
          v-for="header in props.headers"
          :key="header.text"
        >{{ header.text }}</th>
      </tr>
    </template>
    <template v-slot:items="props">
      <tr @click.stop="expand(props)" :class="{ complex: props.item.isComplex}">
        <td>{{props.item.key}}</td>
        <td v-if="props.item.isComplex">{{props.item.value}}</td>
        <attribute-edit-dialog v-else :item="props.item"></attribute-edit-dialog>
        <td class="justify-end layout px-4">
          <v-icon
            :class="{'white--text': props.item.isComplex}"
            small
            @click="deleteItem(props.item)"
          >delete</v-icon>
          <v-icon
            v-if="props.item.isComplex"
            color="white"
            :class="{rotated:props.expanded}"
          >arrow_drop_down</v-icon>
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
</template>

<script>
import axios from 'axios'
import { mapActions, mapGetters } from 'vuex'
import AttributeEditDialog from '~/components/attribute/attribute-edit-dialog.vue'
export default {
  name: 'attribute-grid',
  props: ['items'],
  components: {
    AttributeEditDialog
  },
  data: () => ({
    headers: [
      {
        text: 'Key',
        align: 'left'
      },
      { text: 'Value', sortable: false },
      { text: '', sortable: false }
    ],
    attributes: []
  }),
  methods: {
    ...mapActions(['editValue', 'getAttributesOfComplex']),
    deleteItem(item) {},
    async expand(props) {
      if (props.item.isComplex) {
        if (!props.expanded) {
          this.attributes = await this.getAttributesOfComplex({ key: props.item.key, value: props.item.value })
        }
        props.expanded = !props.expanded
      }
    }
  }
}
</script>

<style scoped>
.complex {
  background: #52a8b6;
  color: #fff;
	cursor: pointer;
	border-bottom: 1px solid white !important;
}
.complex:hover {
  background: #52a8b6 !important;
}
.table-headers{
	background-color:#DCDEE1;
}
.table-headers:hover{
	background-color: #DCDEE1 !important;
}
.table-borders{
	border-left: 1px solid  rgba(0,0,0,0.12);
	border-right: 1px solid  rgba(0,0,0,0.12);
}
.expanded{
	border-bottom: 1px solid rgba(0,0,0,0.12)
}
.rotated{
	transition: transform 0.2s;
	transform: rotate(180deg);
}
</style>