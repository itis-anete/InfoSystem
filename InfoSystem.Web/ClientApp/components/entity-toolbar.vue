<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <attribute-new-dialog></attribute-new-dialog>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
    <v-spacer></v-spacer>
    <v-progress-circular v-if="loading" class="px-5" indeterminate color="primary"></v-progress-circular>
  </v-toolbar>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'
import AttributeNewDialog from '~/components/attribute/new-dialog.vue'
export default {
  components: {
    AttributeNewDialog
  },
  computed: {
    ...mapGetters(['loading'])
  }
}
</script>