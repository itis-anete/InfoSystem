<template>
  <v-toolbar flat color="white" height="48" style="border-bottom: 1px solid #eaeaea !important">
    <v-layout align-center style="height: 100%">
      <v-flex xs12 style="height: 100%; margin-left: 75px">
        <v-toolbar-items>
          <v-divider inset vertical></v-divider>
          <new-entity-dialog></new-entity-dialog>
          <v-divider inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-progress-circular
            v-if="common.loading"
            class="px-5"
            style="height: 30px; margin-top: 9px"
            indeterminate
            color="primary"
          ></v-progress-circular>
        </v-toolbar-items>
      </v-flex>
    </v-layout>
  </v-toolbar>
</template>

<script>
import { mapState } from 'vuex'
import NewEntityDialog from './new/entity-dialog.vue'
export default {
  components: {
    NewEntityDialog
  },
  computed: {
    ...mapState(['common'])
  }
}
</script>
