<template>
  <div>
    <v-data-table
      :headers="headers"
      :items="currentAttributes"
      item-key="id"
      sort-icon="arrow_drop_down"
      hide-actions
    >
      <template v-slot:items="props">
        <tr @click="attributeExpand(props)" :class="{ complex: props.item.isComplex}">
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
          <v-flex v-if="!loading" xs10>
            <grid></grid>
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
import { mapActions, mapGetters } from 'vuex'
import ContentEditDialog from './edit-value-dialog/content-edit-dialog.vue'
import AttributeEditDialog from './edit-value-dialog/attribute-edit-dialog.vue'
import DialogGrid from '~/components/edit-entity/dialog-grid.vue'
export default {
  name: 'grid',
  components: {
    ContentEditDialog,
    AttributeEditDialog,
    DialogGrid
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
        { text: 'Value', value: 'attributeId', sortable: false },
        { text: '', sortable: false }
      ],
      currentAttributes: []
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
        this.$store.dispatch('getAttributesByTypeName', { entityId: props.item.value, typeName: props.item.key.substring(8) })
      }
    }
  },
  computed: {
    ...mapGetters(['attributes', 'loading'])
  },
  mounted() {
    this.currentAttributes = this.attributes
  }
}
</script>

<style scoped>
.complex {
  background: #52a8b6;
  color: #fff;
}
</style>