<template>
  <v-dialog
    v-model="localDialogActive"
    fullscreen
    hide-overlay
    transition="dialog-bottom-transition"
    scrollable
  >
    <v-card tile>
      <v-toolbar card dark color="primary">
        <v-toolbar-title class="ml-4">Edit Entity</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items class="mr-4">
          <v-btn dark flat @click="localDialogActive = false">Save</v-btn>
          <v-btn icon dark @click="localDialogActive = false">
            <v-icon>close</v-icon>
          </v-btn>
        </v-toolbar-items>
      </v-toolbar>
      <v-card-text>
        <dialog-grid></dialog-grid>
      </v-card-text>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'
import DialogGrid from './dialog-grid.vue'
export default {
  props: ['dialogActive'],
  components: {
    DialogGrid
  },
  computed: {
    localDialogActive: {
      get() {
        return this.dialogActive
      },
      set(value) {
        this.$emit('update:dialogActive', value)
      }
    }
  }
}
</script>