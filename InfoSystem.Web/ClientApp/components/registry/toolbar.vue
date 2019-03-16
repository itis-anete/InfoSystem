<template>
  <v-toolbar card color="#eee">
    <v-toolbar-items>
      <new-entity-dialog></new-entity-dialog>
      <v-divider inset vertical></v-divider>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
import NewEntityDialog from '~/components/registry/new-entity-dialog.vue'
export default {
  components: {
    NewEntityDialog
  }
}
</script>
