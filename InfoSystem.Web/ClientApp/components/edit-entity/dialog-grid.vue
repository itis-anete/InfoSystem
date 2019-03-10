<template>
  <div>
    <v-data-table v-if="currentValues" :headers="headers" :items="currentValues" item-key="id">
      <template v-slot:items="props">
        <td>
          <content-edit-dialog
            :item="props.item"
            @update:content="props.item.content = $event; save(props.item)"
          ></content-edit-dialog>
        </td>
        <td>
          <attribute-edit-dialog
            :item="props.item"
            @update:content="props.item.attribute = $event; save(props.item)"
          ></attribute-edit-dialog>
        </td>
        <td class="justify-end layout px-4">
          <v-icon small @click="deleteItem()">delete</v-icon>
        </td>
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
          text: 'Value',
          align: 'left',
          sortable: false
        },
        { text: 'Attribute', value: 'attributeId' },
        { text: '', sortable: false }
      ]
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
    ...mapGetters(['currentValues', 'attributes'])
  }
}
</script>

<style scoped>

</style>