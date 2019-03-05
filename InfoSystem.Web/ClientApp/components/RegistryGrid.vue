<template>
  <div>
    <v-toolbar flat color="white">
      <v-spacer></v-spacer>
      <v-dialog
        v-model="dialog"
        fullscreen
        hide-overlay
        transition="dialog-bottom-transition"
        scrollable
      >
        <template v-slot:activator="{ on }">
          <v-btn color="primary" dark class="mb-2" v-on="on">New Item</v-btn>
        </template>
        <v-card tile>
          <v-toolbar card dark color="primary">
            <v-toolbar-title>Settings</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items>
              <v-btn dark flat @click="dialog = false">Save</v-btn>
              <v-btn icon dark @click="dialog = false">
                <v-icon>close</v-icon>
              </v-btn>
            </v-toolbar-items>
          </v-toolbar>
          <v-card-text>
            <v-list three-line subheader>
              <v-subheader>User Controls</v-subheader>
              <v-list-tile avatar>
                <v-list-tile-content>
                  <v-list-tile-title>Content filtering</v-list-tile-title>
                  <v-list-tile-sub-title>Set the content filtering level to restrict apps that can be downloaded</v-list-tile-sub-title>
                </v-list-tile-content>
              </v-list-tile>
              <v-list-tile avatar>
                <v-list-tile-content>
                  <v-list-tile-title>Password</v-list-tile-title>
                  <v-list-tile-sub-title>Require password for purchase or use password to restrict purchase</v-list-tile-sub-title>
                </v-list-tile-content>
              </v-list-tile>
            </v-list>
            <v-divider></v-divider>
          </v-card-text>

          <div style="flex: 1 1 auto;"></div>
        </v-card>
      </v-dialog>
    </v-toolbar>
    <v-data-table :headers="headers" :items="items" class="elevation-1">
      <template v-slot:items="props">
        <td v-for="key in Object.keys(props.item)">{{ props.item[key] }}</td>
        <td class="justify-center layout px-0">
          <v-icon small class="mr-2" @click="editItem(props.item)">edit</v-icon>
          <v-icon small @click="deleteItem(props.item)">delete</v-icon>
        </td>
      </template>
    </v-data-table>
  </div>
</template>

<script>
export default {
  props: ['headers', 'items'],
  data: () => ({
    dialog: false,
    editedIndex: -1,
    editedItem: { name: '', calories: 0, fat: 0, carbs: 0, protein: 0 },
    defaultItem: { name: '', calories: 0, fat: 0, carbs: 0, protein: 0 }
  }),

  computed: {
    formTitle() {
      return this.editedIndex === -1 ? 'New Item' : 'Edit Item'
    }
  },

  watch: {
    dialog(val) {
      val || this.close()
    }
  },

  created() {},

  methods: {
    editItem(item) {
      this.dialog = true
      this.$store.dispatch('getValues', { entityId: item.id, typeId: item.typeId })
    },

    deleteItem(item) {
      const index = this.items.indexOf(item)
      confirm('Are you sure you want to delete this item?') && this.items.splice(index, 1)
    },

    close() {
      this.dialog = false
      setTimeout(() => {
        this.editedItem = Object.assign({}, this.defaultItem)
        this.editedIndex = -1
      }, 300)
    },

    save() {
      if (this.editedIndex > -1) {
        Object.assign(this.items[this.editedIndex], this.editedItem)
      } else {
        this.items.push(this.editedItem)
      }
      this.close()
    }
  }
}
</script>