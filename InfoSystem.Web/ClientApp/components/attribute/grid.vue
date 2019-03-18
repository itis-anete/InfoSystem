<template>
  <v-data-table :headers="headers" :items="attributes" item-key="id" sort-icon="arrow_drop_down">
    <template v-slot:items="props">
      <tr @click="linkTo(props.item)" :class="{link : props.item.isComplex}">
        <td>{{props.item.key}}</td>
        <td v-if="props.item.isComplex">{{props.item.value}}</td>
        <attribute-edit-dialog v-else :item="props.item"></attribute-edit-dialog>
        <attribute-delete-dialog :item="props.item"></attribute-delete-dialog>
      </tr>
    </template>
  </v-data-table>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import AttributeEditDialog from '~/components/attribute/edit-dialog.vue'
import AttributeDeleteDialog from '~/components/attribute/delete-dialog.vue'
export default {
  name: 'attribute-grid',
  props: ['attributes'],
  components: {
    AttributeEditDialog,
    AttributeDeleteDialog
  },
  data: () => ({
    headers: [
      {
        text: 'Key',
        align: 'left',
        sortable: false
      },
      { text: 'Value', sortable: false },
      { text: '', sortable: false }
    ]
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
  cursor: pointer;
}
</style>