<template>
  <v-dialog
    v-model="localDialog"
    fullscreen
    hide-overlay
    transition="dialog-bottom-transition"
    scrollable
  >
    <v-card tile>
      <v-toolbar card dark color="primary">
        <v-toolbar-title>Edit Entity</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items>
          <v-btn dark flat @click="localDialog = false">Save</v-btn>
          <v-btn icon dark @click="localDialog = false">
            <v-icon>close</v-icon>
          </v-btn>
        </v-toolbar-items>
      </v-toolbar>
      <v-card-text>
        <v-list three-line subheader>
          <v-subheader>Attributes</v-subheader>
          <v-list-tile avatar v-for="value in currentValues" :key="value.id">
            <v-list-tile-content>
              <v-text-field :label="value.attribute.name" v-model="value.content"></v-text-field>
            </v-list-tile-content>
          </v-list-tile>
        </v-list>
        <v-divider></v-divider>
      </v-card-text>

      <div style="flex: 1 1 auto;"></div>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  props: ['dialog'],
  data() {
    return {}
  },
  computed: {
    ...mapGetters(['currentValues']),
    localDialog: {
      get() {
        return this.dialog
      },
      set(value) {
        this.$emit('update:dialog', value)
      }
    }
  }
}
</script>