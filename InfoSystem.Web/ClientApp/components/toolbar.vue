<template>
  <v-toolbar flat color="white" height="48" style="border-bottom: 1px solid rgba(0,0,0,0.12) !important">
    <v-layout align-center style="height: 100%">
      <v-flex xs12 style="height: 100%; margin-left: 4.1666666667%">
        <v-toolbar-items>
          <transition name="page" mode="out-in"><component :is="newDialog"/></transition>
          <v-spacer />
        </v-toolbar-items>
      </v-flex>
    </v-layout>
  </v-toolbar>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'nuxt-property-decorator'

import NewEntityDialog from './registry/new/entity-dialog.vue'
import PropertyNewDialog from '~/components/property/new-dialog.vue'

@Component({
  name: 'Grid',
  components: {
    NewEntityDialog,
    PropertyNewDialog
  }
})
export default class extends Vue {
  @Prop(String) readonly newDialog!: string
}
</script>
