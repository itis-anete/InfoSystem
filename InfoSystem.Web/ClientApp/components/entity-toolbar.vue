<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <attribute-new-dialog></attribute-new-dialog>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
import { mapActions } from 'vuex'
import AttributeNewDialog from '~/components/attribute/new-dialog.vue'
export default {
  components: {
    AttributeNewDialog
  }
}
</script>