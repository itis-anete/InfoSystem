<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <property-new-dialog></property-new-dialog>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
    <v-spacer></v-spacer>
    <v-progress-circular v-if="loading" class="px-5" indeterminate color="primary"></v-progress-circular>
  </v-toolbar>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import PropertyNewDialog from '~/components/property/new-dialog.vue'
export default {
  components: {
    PropertyNewDialog
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>