<template>
  <v-toolbar flat color="white" height="48" style="border-bottom: 1px solid rgba(0,0,0,0.12) !important">
    <v-layout align-center style="height: 100%">
      <v-flex xs12 style="height: 100%; margin-left: 4.1666666667%">
        <v-toolbar-items>
          <component :is="newDialog"></component>
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
import NewEntityDialog from './registry/new/entity-dialog.vue'
import PropertyNewDialog from '~/components/property/new-dialog.vue'
export default {
  components: {
    NewEntityDialog,
    PropertyNewDialog
  },
  props: ['newDialog'],
  computed: {
    ...mapState(['common'])
  }
}
</script>
