<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="attributes"
      item-key="id"
      sort-icon="arrow_drop_down"
      :rows-per-page-items="rowsPerPageItems"
      :pagination.sync="pagination"
      :loading="loading"
    >
      <template v-slot:items="props">
        <tr :class="{ complex: props.item.isComplex}">
          <td>{{props.item.key}}</td>
          <td>{{props.item.value}}</td>
          <!-- <content-edit-dialog
            :item="props.item"
            @update:content="props.item.content = $event; save(props.item)"
          ></content-edit-dialog>
          <attribute-edit-dialog
            :item="props.item"
            @update:attribute="props.item.attribute = $event; save(props.item)"
          ></attribute-edit-dialog>-->
          <td class="justify-end layout px-4">
            <v-icon small @click="deleteItem()">delete</v-icon>
          </td>
        </tr>
      </template>
    </v-data-table>
    <v-snackbar v-model="snack" :timeout="3000" :color="snackColor">
      {{ snackText }}
      <v-btn flat @click="snack = false">Close</v-btn>
    </v-snackbar>
  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import ContentEditDialog from './edit-value-dialog/content-edit-dialog.vue'
import AttributeEditDialog from './edit-value-dialog/attribute-edit-dialog.vue'
export default {
  components: {
    ContentEditDialog,
    AttributeEditDialog
  },
  data() {
    return {
      snack: false,
      snackColor: '',
      snackText: '',
      headers: [
        {
          text: 'Key',
          align: 'left',
          sortable: false
        },
        { text: 'Value', value: 'attributeId' },
        { text: '', sortable: false }
      ],
      rowsPerPageItems: [10, 20, 100, { text: '$vuetify.dataIterator.rowsPerPageAll', value: -1 }],
      pagination: {
        rowsPerPage: 10
      }
    }
  },
  methods: {
    ...mapActions(['editValue']),
    save(item) {
      const value = {
        id: item.id,
        content: item.content,
        entityId: item.entityId,
        attributeId: item.attribute.id
      }
      this.editValue(value)
      this.setSnack('Data saved', 'success')
    },
    setSnack(text, color) {
      this.snack = true
      this.snackColor = color
      this.snackText = text
    },
    deleteItem() {}
  },
  computed: {
    ...mapGetters(['attributes', 'loading'])
  }
}
</script>

<style scoped>
.complex{
	background: #52A8B6;
	color: #fff
}
</style>