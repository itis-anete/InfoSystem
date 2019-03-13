<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="items"
      item-key="id"
      sort-icon="arrow_drop_down"
      hide-actions
    >
      <template v-slot:items="props">
        <tr @click.stop="attributeExpand(props)" :class="{ complex: props.item.isComplex}">
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
      <template v-slot:expand="props">
        <v-layout justify-end>
          <v-flex xs10>
            <dialog-grid :items="attributes"></dialog-grid>
          </v-flex>
        </v-layout>
      </template>
    </v-data-table>
    <v-snackbar v-model="snack" :timeout="3000" :color="snackColor">
      {{ snackText }}
      <v-btn flat @click="snack = false">Close</v-btn>
    </v-snackbar>
  </div>
</template>

<script>
import axios from 'axios'
import { mapActions, mapGetters } from 'vuex'
import ContentEditDialog from './edit-value-dialog/content-edit-dialog.vue'
import AttributeEditDialog from './edit-value-dialog/attribute-edit-dialog.vue'
export default {
  name: 'dialog-grid',
  components: {
    ContentEditDialog,
    AttributeEditDialog
  },
  props: ['items'],
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
        { text: 'Value', value: 'attributeId', sortable: false },
        { text: '', sortable: false }
      ],
      attributes: []
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
    deleteItem() {},
    attributeExpand(props) {
      if (props.item.isComplex) {
        props.expanded = !props.expanded
        axios
          .get(`/api/Attribute/GetByTypeName?entityId=${props.item.value}&typeName=${props.item.key.substring(8)}`)
          .then(response => (this.attributes = response.data))
      }
    }
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>

<style scoped>
.complex {
  background: #52a8b6;
  color: #fff;
}
</style>