<template>
  <v-dialog
    v-model="dialog"
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
          <v-btn dark flat @click="dialog = false">Save</v-btn>
          <v-btn icon dark @click="dialog = false">
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
  data: () => ({}),
  watch: {
    dialog(val) {
      this.$emit('dialogChange', val)
    }
  },
  computed: {
    ...mapGetters(['currentValues'])
  }
}
</script>