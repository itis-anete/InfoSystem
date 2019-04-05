<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <new-entity-dialog></new-entity-dialog>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
    <v-spacer></v-spacer>
    <v-progress-circular v-if="loading" class="px-5" indeterminate color="primary"></v-progress-circular>
  </v-toolbar>
</template>

<script>
import { mapState } from 'vuex'
import NewEntityDialog from './new-entity-dialog.vue'
export default {
  components: {
    NewEntityDialog
  },
  computed: {
    ...mapState(['loading'])
  }
}
</script>