<template>
  <td class="justify-end layout px-4">
    <v-edit-dialog @click.native.stop lazy persistent ref="deleteDialog">
      <v-btn flat icon>
        <v-icon small>delete</v-icon>
      </v-btn>
      <template v-slot:input>
        <p class="pt-3 pb-1 ma-0 text-xs-center">Are you sure?</p>
        <v-btn color="error" flat @click="clear">no</v-btn>
        <v-btn color="success" flat @click="onRemove">yes</v-btn>
      </template>
    </v-edit-dialog>
  </td>
</template>

<script>
import { mapActions } from 'vuex'
export default {
  props: ['remove'],
  methods: {
    onRemove() {
      this.remove()
      this.clear()
    },
    clear() {
      this.$refs['deleteDialog'].isActive = false
    }
  }
}
</script>